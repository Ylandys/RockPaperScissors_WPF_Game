using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace RockPaperScissors
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Определение дальнейших переменных
        DispatcherTimer _timer;
        TimeSpan _time;

        int rounds = 3;
        
        bool gameOver = false;

        string[] ComputerChooseList = { "rock", "paper", "scissor", "paper", "scissor", "rock" };

        int randomNumber = 0;

        Random random = new Random();

        string ComputerChoose;
        string PlayerChoose;

        int playerScore;
        int ComputerScore;

        public MainWindow()
        {
            InitializeComponent();

            ImagesPath();
            ResultTimer();

            txtWinsComputer.Text = Convert.ToString($"Побед: {ComputerScore}");
            txtWinsPlayer.Text = Convert.ToString($"Побед: {playerScore}");
            txtRound.Text = Convert.ToString($"Раунд: {rounds}");


        }

        private void ResultTimer()
        {
            _time = TimeSpan.FromSeconds(5);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                
                txtTimer.Text = _time.ToString("c");
                if (_time == TimeSpan.Zero)
                {
                    randomNumber = random.Next(0, ComputerChooseList.Length);
                    ComputerChoose = ComputerChooseList[randomNumber];

                    switch (ComputerChoose)
                    {
                        case "rock":
                            ComputerName.ImageSource = new BitmapImage(new Uri("D:\\RentalCarProject\\RockPaperScissors\\RockPaperScissors\\Resources\\stone.png", UriKind.Absolute));
                            break;

                        case "scissor":
                            ComputerName.ImageSource = new BitmapImage(new Uri("D:\\RentalCarProject\\RockPaperScissors\\RockPaperScissors\\Resources\\scissors.png", UriKind.Absolute));
                            break;

                        case "paper":
                            ComputerName.ImageSource = new BitmapImage(new Uri("D:\\RentalCarProject\\RockPaperScissors\\RockPaperScissors\\Resources\\parchment.png", UriKind.Absolute));
                            break;
                    }

                    if (rounds > 0)
                    {
                        checkGame();
                    }
                    else
                    {
                        if (playerScore > ComputerScore)
                        {
                            MessageBox.Show("ВЫ ПОБЕДИЛИ!");
                        }
                        else
                        {
                            MessageBox.Show("ВЫ ПРОИГРАЛИ!");
                        }

                        gameOver = true;
                    }
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

        }

        private void btnRockClick_ChooseStone(object sender, RoutedEventArgs e)
        {
            PlayerChoose = "rock";
            Player.ImageSource = new BitmapImage(new Uri("D:\\RentalCarProject\\RockPaperScissors\\RockPaperScissors\\Resources\\stone.png", UriKind.Absolute));
    
        }

        private void btnScissorsClick_ChooseScissors(object sender, RoutedEventArgs e)
        {
            PlayerChoose = "scissor";
            Player.ImageSource = new BitmapImage(new Uri("D:\\RentalCarProject\\RockPaperScissors\\RockPaperScissors\\Resources\\scissors.png", UriKind.Absolute));
        }

        private void btnPapperClick_ChoosePapper(object sender, RoutedEventArgs e)
        {
            PlayerChoose = "paper";
            Player.ImageSource = new BitmapImage(new Uri("D:\\RentalCarProject\\RockPaperScissors\\RockPaperScissors\\Resources\\parchment.png", UriKind.Absolute));
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            _time = TimeSpan.FromSeconds(5);
            _timer.Start();
            playerScore = 0;
            ComputerScore = 0;
            rounds = 3;

            txtWinsComputer.Text = Convert.ToString($"Побед: {ComputerScore}");
            txtWinsPlayer.Text = Convert.ToString($"Побед: {playerScore}");
            txtRound.Text = Convert.ToString($"Раунд: {rounds}");
            gameOver = false;

            Player.ImageSource = new BitmapImage(new Uri("D:\\RentalCarProject\\RockPaperScissors\\RockPaperScissors\\Resources\\gamer.png", UriKind.Absolute));
            ComputerName.ImageSource = new BitmapImage(new Uri("D:\\RentalCarProject\\RockPaperScissors\\RockPaperScissors\\Resources\\robot.png", UriKind.Absolute));


        }


        //Доп методы
        private void checkGame()
        {
            if (PlayerChoose == "rock" && ComputerChoose == "paper")
            {
                ComputerScore += 1;
                rounds -= 1;

                txtWinsComputer.Text = Convert.ToString($"Побед: {ComputerScore}");
                txtRound.Text = Convert.ToString($"Раунд: {rounds}");

                MessageBox.Show("Вы проиграли! Бумага бьет камень");
            }
            else if (PlayerChoose == "scissor" && ComputerChoose == "rock")
            {
                ComputerScore += 1;
                rounds -= 1;

                txtWinsComputer.Text = Convert.ToString($"Побед: {ComputerScore}");
                txtRound.Text = Convert.ToString($"Раунд: {rounds}");

                MessageBox.Show("Вы проиграли! Камень бьет ножницы");
            }
            else if (PlayerChoose == "paper" && ComputerChoose == "scissor")
            {
                ComputerScore += 1;
                rounds -= 1;

                txtWinsComputer.Text = Convert.ToString($"Побед: {ComputerScore}");
                txtRound.Text = Convert.ToString($"Раунд: {rounds}");

                MessageBox.Show("Вы проиграли! Ножницы бьют бумагу");
            }

            if (PlayerChoose == "rock" && ComputerChoose == "scissor")
            {
                playerScore += 1;
                rounds -= 1;

                txtWinsPlayer.Text = Convert.ToString($"Побед: {playerScore}");
                txtRound.Text = Convert.ToString($"Раунд: {rounds}");

                MessageBox.Show("Победа! Камень бьет ножницы");

            }
            else if (PlayerChoose == "paper" && ComputerChoose == "rock")
            {
                playerScore += 1;
                rounds -= 1;

                txtWinsPlayer.Text = Convert.ToString($"Побед: {playerScore}");
                txtRound.Text = Convert.ToString($"Раунд: {rounds}");

                MessageBox.Show("Победа!, Бумага бьет камень");
            }
            else if (PlayerChoose == "scissor" && ComputerChoose == "paper")
            {
                playerScore += 1;
                rounds -= 1;

                txtWinsPlayer.Text = Convert.ToString($"Побед: {playerScore}");
                txtRound.Text = Convert.ToString($"Раунд: {rounds}");

                MessageBox.Show("Победа! Ножницы бьют бумагу");
            }

            else if (PlayerChoose == "rock" && ComputerChoose == "rock")
            {

                MessageBox.Show("Ничья!");
            }

            else if (PlayerChoose == "scissor" && ComputerChoose == "scissor")
            {

                MessageBox.Show("Ничья!");
            }

            else if (PlayerChoose == "paper" && ComputerChoose == "paper")
            {

                MessageBox.Show("Ничья!");
            }


            else if(PlayerChoose == "none")
            {
                MessageBox.Show("Сделайте выбор!");
            }

            startNextRound();
        }
        public void startNextRound()
        {
            if (gameOver)
            {
                return;
            }

            _time = TimeSpan.FromSeconds(5);
            _timer.Start();
            Player.ImageSource = new BitmapImage(new Uri("D:\\RentalCarProject\\RockPaperScissors\\RockPaperScissors\\Resources\\gamer.png", UriKind.Absolute));
            ComputerName.ImageSource = new BitmapImage(new Uri("D:\\RentalCarProject\\RockPaperScissors\\RockPaperScissors\\Resources\\robot.png", UriKind.Absolute));


        }
        private void ImagesPath()
        {
            //Картинка Камня
            ImageRock.ImageSource = new BitmapImage(new Uri("D:\\RentalCarProject\\RockPaperScissors\\RockPaperScissors\\Resources\\stone.png", UriKind.Absolute));

            //Картинка Ножниц
            ImageScissors.ImageSource = new BitmapImage(new Uri("D:\\RentalCarProject\\RockPaperScissors\\RockPaperScissors\\Resources\\scissors.png", UriKind.Absolute));

            //Картинка Бумаги
            ImagePapper.ImageSource = new BitmapImage(new Uri("D:\\RentalCarProject\\RockPaperScissors\\RockPaperScissors\\Resources\\parchment.png", UriKind.Absolute));

            //Картинка Игрока
            Player.ImageSource = new BitmapImage(new Uri("D:\\RentalCarProject\\RockPaperScissors\\RockPaperScissors\\Resources\\gamer.png", UriKind.Absolute));

            //Картинка Компьютера
            ComputerName.ImageSource = new BitmapImage(new Uri("D:\\RentalCarProject\\RockPaperScissors\\RockPaperScissors\\Resources\\robot.png", UriKind.Absolute));

            //Картинка Рестарта

            ImageRestart.ImageSource = new BitmapImage(new Uri("D:\\RentalCarProject\\RockPaperScissors\\RockPaperScissors\\Resources\\synchronize.png", UriKind.Absolute));
        }

        private void btnClick_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
