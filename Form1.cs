using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace PA5_Draft
{
    public partial class MainForm : Form
    {
        private int Step = 1;
        private readonly SnakeGame Game;
        private int NumberOfApples = 1;//the minimum number of apples is 1
        private int applesEaten = 0;
        private int alpha = 0;
        private bool GameOver = false;
        private long counter = 0;
        private const int Max_Apple_Size = 15;
        private const int Min_Apple_Size = 10;
        //Playing sounds when trigger three events: EatAndGrow, HitWallAndLose, and HitSnakeAndLose
        System.Media.SoundPlayer eatApples = new System.Media.SoundPlayer(Properties.Resources.bit_apple);
        System.Media.SoundPlayer hitsnake = new System.Media.SoundPlayer(Properties.Resources.hit_snake);
        System.Media.SoundPlayer hitwall = new System.Media.SoundPlayer(Properties.Resources.hit_wall);

        public MainForm()
        {
            Custom custom = new Custom();
            DialogResult result = custom.ShowDialog();
            if (result == DialogResult.OK)
                NumberOfApples = custom.number_Of_Apples;
            InitializeComponent();
            Game = new SnakeGame(new System.Drawing.Point((Field.Width - 20) / 2, Field.Height / 2), 40, NumberOfApples, Field.Size);
            Field.Image = new Bitmap(Field.Width, Field.Height);
            Game.EatAndGrow += Game_EatAndGrow;
            Game.HitWallAndLose += Game_HitWallAndLose;
            Game.HitSnakeAndLose += Game_HitSnakeAndLose;
        }

        private void Game_HitWallAndLose()
        {
            mainTimer.Stop();//Game Over
            GameOver = true;
            Field.Refresh();
            hitwall.Play();//playing sound when trigger hitwall event
        }

        private void Game_HitSnakeAndLose()
        {
            mainTimer.Stop();//Game Over
            GameOver = true;
            Field.Refresh();
            hitsnake.Play();//playing sound when trigger hitsnake event
        }

        private void Game_EatAndGrow()
        {
            applesEaten++;
            alpha = 255;
            if (Step < 10)//The maximum of speed of the snake is 10
            {
                if ((applesEaten % 10) == 0)//After every 10 eaten apples, the speed of snake increases
                {
                    Step++;
                    progressBar1.Value = Step;//show the current value of Step
                }
            }
            eatApples.Play();//playing sound when trigger EatAndGrow event
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            counter++;
            Game.Move(Step);
            Field.Invalidate();
        }

        private void Field_Paint(object sender, PaintEventArgs e)
        {
            Pen PenForObstacles = new Pen(Color.FromArgb(40, 40, 40), 5);
            Pen PenForSnake = new Pen(Color.FromArgb(100, 0, 255), 4);
            Brush BackGroundBrush = new SolidBrush(Color.FromArgb(150, 250, 150));
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;//set the message text showing on the center of the layout rectangle

            using (Graphics g = Graphics.FromImage(Field.Image))
            {
                g.FillRectangle(BackGroundBrush, new Rectangle(0, 0, Field.Width, Field.Height));
                int opacity, i = 0;
                long c, phase;
                double applesize;

                foreach (Point Apple in Game.Apples)
                {
                    c = counter + (i++);
                    phase = (c / 20) % 4;
                    if (phase == 0)
                        applesize = (c % 80.0 - 20 * phase) * (Max_Apple_Size - Min_Apple_Size) / 40.0 + (Max_Apple_Size + Min_Apple_Size) / 2.0;
                    else if (phase == 1)
                        applesize = -(c % 80.0 - 20 * phase) * (Max_Apple_Size - Min_Apple_Size) / 40.0 + Max_Apple_Size;
                    else if (phase == 2)
                        applesize = -(c % 80.0 - 20 * phase) * (Max_Apple_Size - Min_Apple_Size) / 40.0 + (Max_Apple_Size + Min_Apple_Size) / 2.0;
                    else
                        applesize = (c % 80.0 - 20 * phase) * (Max_Apple_Size - Min_Apple_Size) / 40.0 + Min_Apple_Size;

                    opacity = 255 - (int)Math.Floor((applesize - Min_Apple_Size) * 190.0 / (Max_Apple_Size - Min_Apple_Size));
                    Brush AppleBrush = new SolidBrush(Color.FromArgb(opacity, 250, 50, 50));
                    g.FillEllipse(AppleBrush, new Rectangle(Apple.X - (int)Math.Round(applesize),
                                  Apple.Y - (int)Math.Round(applesize), 2 * (int)Math.Round(applesize),
                                  2 * (int)Math.Round(applesize)));
                }
                foreach (LineSeg Obstacle in Game.Obstacles)
                    g.DrawLine(PenForObstacles, new System.Drawing.Point(Obstacle.Start.X, Obstacle.Start.Y)
                              , new System.Drawing.Point(Obstacle.End.X, Obstacle.End.Y));

                foreach (LineSeg Body in Game.SnakeBody)
                    g.DrawLine(PenForSnake, new System.Drawing.Point((int)Body.Start.X, (int)Body.Start.Y)
                              , new System.Drawing.Point((int)Body.End.X, (int)Body.End.Y));

                if (GameOver)
                {
                    alpha = (alpha + 1) % 256;
                    g.DrawString("Game Over!\nNumber of Eaten Apples: " + applesEaten,
                        new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold),
                        new SolidBrush(Color.FromArgb(alpha, Color.FromName("Black"))),
                        new PointF(Field.Width / 2, 235), stringFormat);
                    Field.Invalidate();
                }
                else
                {
                    alpha = alpha < 30 ? 0 : alpha - 5;
                    g.DrawString("" + applesEaten, new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold),
                        new SolidBrush(Color.FromArgb(alpha, Color.FromName("White"))),
                        new PointF(Field.Width / 2, 250), stringFormat);
                }
            }
        }

        private void Snakes_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    Game.Move(Step, Direction.UP);
                    break;
                case Keys.Down:
                    Game.Move(Step, Direction.DOWN);
                    break;
                case Keys.Left:
                    Game.Move(Step, Direction.LEFT);
                    break;
                case Keys.Right:
                    Game.Move(Step, Direction.RIGHT);
                    break;
            }
        }

        //pause and resume the game
        private void Field_Click(object sender, EventArgs e)
        {
            if (GameOver == false)
            {
                if (mainTimer.Enabled)
                    mainTimer.Stop();
                else
                    mainTimer.Start();
            }
        }
    }
}
