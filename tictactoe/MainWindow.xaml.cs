using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tictactoe
{
    public partial class MainWindow : Window
    {
        private Button[] btns = new Button[9];
        private bool isPlayerTurn { get; set; }
        private int Counter { get; set; }
        public bool isWinner = false;
        private Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();

            btns[0] = btn0;
            btns[1] = btn1;
            btns[2] = btn2;
            btns[3] = btn3;
            btns[4] = btn4;
            btns[5] = btn5;
            btns[6] = btn6;
            btns[7] = btn7;
            btns[8] = btn8;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (isWinner || !string.IsNullOrEmpty(button.Content as string))
            {
                return;
            }

            if (isPlayerTurn)
            {
                Panel.Content = "Gracz 1";
            }
            else
            {
                Panel.Content = "Gracz 2";
            }
            if (button.Content.Equals(""))
            {
                button.Background = isPlayerTurn ? Brushes.Blue : Brushes.Red;
                button.Content = isPlayerTurn ? "O" : "X";
            }
            isPlayerTurn = !isPlayerTurn;
            getWinner();
        }

        private void getWinner()
        {
            foreach (var btn in btns)
            {
                if(btn != null && !btn.Content.Equals(""))
                {
                    Counter++;
                }
            }

            if(!btn0.Content.Equals("") && btn0.Content.Equals(btn1.Content) && btn0.Content.Equals(btn2.Content))
            {
                WonGame(btn0, btn1, btn2);
                isWinner = true;
                Counter = 0;
            }
            if (!btn3.Content.Equals("") && btn3.Content.Equals(btn4.Content) && btn3.Content.Equals(btn5.Content))
            {
                WonGame(btn3, btn4, btn5);
                isWinner = true;
                Counter = 0;
            }
            if (!btn6.Content.Equals("") && btn6.Content.Equals(btn7.Content) && btn6.Content.Equals(btn8.Content))
            {
                WonGame(btn6, btn7, btn8);
                isWinner = true;
                Counter = 0;
            }
            if (!btn0.Content.Equals("") && btn0.Content.Equals(btn3.Content) && btn0.Content.Equals(btn6.Content))
            {
                WonGame(btn0, btn3, btn6);
                isWinner = true;
                Counter = 0;
            }
            if (!btn1.Content.Equals("") && btn1.Content.Equals(btn4.Content) && btn1.Content.Equals(btn7.Content))
            {
                WonGame(btn1, btn4, btn7);
                isWinner = true;
                Counter = 0;
            }
            if (!btn2.Content.Equals("") && btn2.Content.Equals(btn5.Content) && btn2.Content.Equals(btn8.Content))
            {
                WonGame(btn2, btn5, btn8);
                isWinner = true;
                Counter = 0;
            }
            if (!btn0.Content.Equals("") && btn0.Content.Equals(btn4.Content) && btn0.Content.Equals(btn8.Content))
            {
                WonGame(btn0, btn4, btn8);
                isWinner = true;
                Counter = 0;
            }
            if (!btn2.Content.Equals("") && btn2.Content.Equals(btn4.Content) && btn2.Content.Equals(btn6.Content))
            {
                WonGame(btn2, btn4, btn6);
                isWinner = true;
                Counter = 0;
            }
            if(Counter == btns.Length && !isWinner)
            {
                Panel.Content = "Remis";
                Counter = 0;
            }
        }

        private void WonGame(Button b1, Button b2, Button b3)
        {
            b1.Background = Brushes.Green;
            b2.Background = Brushes.Green;
            b3.Background = Brushes.Green;

            b1.Foreground = Brushes.White;
            b2.Foreground = Brushes.White;
            b3.Foreground = Brushes.White;

            b1.BorderBrush = Brushes.White;
            b2.BorderBrush = Brushes.White;
            b3.BorderBrush = Brushes.White;

            if (isPlayerTurn)
            {
                Panel.Content = "Zwyciężył gracz 1";
            }
            else
            {
                Panel.Content = "Zwyciężył gracz 2";
            }
        }

        private void btn_Restart(object sender, RoutedEventArgs e)
        {
            Panel.Content = "Gracz 1";
            Counter = 0;
            isWinner = false;

            foreach (var btn in btns)
            {
                btn.Background = Brushes.LightSlateGray;
                btn.Content = "";
                btn.BorderBrush = Brushes.Black;
                btn.Foreground = Brushes.Black;
                btn.IsEnabled = true;
            }
        }

        private void btn_Block(object sender, RoutedEventArgs e)
        {
            var btnsList = btns.Where(btn => btn.Content.Equals("")).ToList();
            if (btnsList.Any())
            {
                var blockedButton = random.Next(0, btnsList.Count);

                btnsList[blockedButton].Background = Brushes.Khaki;
                btnsList[blockedButton].Content = "🗿";
                Counter++;
            }
        }
    }
}