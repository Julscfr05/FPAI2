using Microsoft.Maui.Controls;
using System;

namespace FPAI
{
    public partial class NewPage8 : ContentPage
    {
        private int currentQuestion = 1;
        private string correctAnswer;  

        public NewPage8()
        {
            InitializeComponent();
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            
            string questionText = "";
            string[] answers = new string[4];
            
            if (currentQuestion == 1)
            {
                questionText = "¿Cuál es el color del sable de luz de Luke Skywalker?";
                correctAnswer = "Azul";
                answers = new[] { "Azul", "Verde", "Rojo", "Naranja" };
            }
            else if (currentQuestion == 2)
            {
                questionText = "¿Cuál es el color del sable de luz de Mace Windu?";
                correctAnswer = "Púrpura";
                answers = new[] { "Púrpura", "Verde", "Azul", "Rojo" };
            }
            else if (currentQuestion == 3)
            {
                questionText = "¿Cuál es el rol en el juego de Yoda?";
                correctAnswer = "Sabio Jedi defensor";
                answers = new[] { "Sabio Jedi defensor", "Jedi versátil", "Joven Jedi", "Villano poderoso" };
            }
            else if (currentQuestion == 4)
            {
                questionText = "¿Cuál es el color del sable de luz de Darth Vader?";
                correctAnswer = "Rojo";
                answers = new[] { "Rojo", "Verde", "Azul", "Naranja" };
            }
            else if (currentQuestion == 5)
            {
                questionText = "¿Qué habilidad especial tiene Ahsoka Tano?";
                correctAnswer = "Estilo Dual";
                answers = new[] { "Estilo Dual", "Telequinesis", "Vaapad", "Defensa Maestra" };
            }
            else if (currentQuestion == 6)
            {
                questionText = "¿Cuál es el color del sable de luz de Ahsoka Tano?";
                correctAnswer = "Naranja y verde";
                answers = new[] { "Naranja y verde", "Azul y verde", "Púrpura", "Rojo" };
            }
            else if (currentQuestion == 7)
            {
                questionText = "¿Qué habilidad especial es utilizada por Mace Windu?";
                correctAnswer = "Vaapad";
                answers = new[] { "Vaapad", "Telequinesis", "Defensa Maestra", "Evasión Ágil" };
            }
            else
            {
            
                QuestionLabel.Text = "¡Cuestionario completado!";
                Button1.IsVisible = false;
                Button2.IsVisible = false;
                Button3.IsVisible = false;
                Button4.IsVisible = false;
                FeedbackLabel.Text = "";
                NextButton.IsVisible = false;
                return;
            }

            QuestionLabel.Text = questionText;



            Random rand = new Random();
            int[] order = { 0, 1, 2, 3 };
            for (int i = order.Length - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);
                int temp = order[i];
                order[i] = order[j];
                order[j] = temp;
            }


            Button1.Text = answers[order[0]];
            Button2.Text = answers[order[1]];
            Button3.Text = answers[order[2]];
            Button4.Text = answers[order[3]];
        }

        private void OnAnswerButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
     
                bool isCorrect = clickedButton.Text == correctAnswer;

                FeedbackLabel.Text = isCorrect ? "¡Correcto!" : "Incorrecto. Inténtalo de nuevo.";
                FeedbackLabel.TextColor = isCorrect ? Colors.Green : Colors.Red;

                NextButton.IsVisible = isCorrect;
            }
        }

        private void OnNextButtonClicked(object sender, EventArgs e)
        {
            currentQuestion++;
            LoadQuestion();
            FeedbackLabel.Text = string.Empty;
            NextButton.IsVisible = false;
        }

        private async void OnHomeButtonClicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new NewPage3());
        }
    }
}
