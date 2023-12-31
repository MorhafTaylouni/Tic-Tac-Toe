namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {

        public enum Player
        {
            X,O
        }

        Player currentPlayer;
        Random random = new Random();
        int playerWinCounter = 0;
        int AIWinCounter = 0;
        List<Button> buttons;

        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CPUmove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                var button = (Button)sender;

                currentPlayer = Player.O;
                button.Text = currentPlayer.ToString();
                button.Enabled = false;
                button.BackColor = Color.Orange;
                buttons.Remove(button);
                CheckGame();
                CPUTimer.Start();
            }
        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            var button = (Button)sender;

            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.Cyan;
            buttons.Remove(button);
            CheckGame();
            CPUTimer.Start();
        }

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void CheckGame()
        {
            if(
                //---------------------WAAGRECHT CHECK---------------------//
                button1.Text == "X" && button2.Text =="X" && button3.Text =="X"
               || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
               || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
               //---------------------SENKRECHT CHECK---------------------//
               || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
               || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
               || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
               //---------------------DIAGONAL CHECK---------------------//
               || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
               || button3.Text == "X" && button5.Text == "X" && button7.Text == "X"
              )
            {
                CPUTimer.Stop();
                MessageBox.Show("X Wins");
                playerWinCounter++;
                label1.Text = "Player Wins " + playerWinCounter;
                RestartGame();
            }
            else if ( //---------------------WAAGRECHT CHECK---------------------//
                button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
               || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
               || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
               //---------------------SENKRECHT CHECK---------------------//
               || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
               || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
               || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
               //---------------------DIAGONAL CHECK---------------------//
               || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
               || button3.Text == "O" && button5.Text == "O" && button7.Text == "O"
               )
            {
                CPUTimer.Stop();
                MessageBox.Show("O Wins");
                AIWinCounter++;
                label2.Text = "AI Wins " + AIWinCounter;
                RestartGame();
            }
        }
        
        private void RestartGame()
        {
           buttons = new List<Button> {button1, button2, button3, button4, button5, button6,
                button7, button8, button9 };

            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = "";
                x.BackColor = DefaultBackColor;
            }
        }

        private void RestartButton(object sender, EventArgs e)
        {
            RestartGame();
        }

        
    }
}