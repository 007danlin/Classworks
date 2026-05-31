using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using GameOfLife.Core;

namespace GameOfLife.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game game;
        private Border[,] cells;
        private DispatcherTimer timer;

        
        public MainWindow()
        {
            InitializeComponent();

            game = new Game();
            cells = new Border[game.Rows, game.Cols];
            CreateGameGrid();
            UpdateVisual();

        }
        private void CreateGameGrid()
        {
            gameGrid.Children.Clear();
            gameGrid.Rows = game.Rows;
            gameGrid.Columns = game.Cols;
            for (int i = 0; i < game.Rows; i++)
            {
                for (int j = 0; j < game.Cols; j++)
                {
                    Border border = new Border
                    {
                        Background = Brushes.Black,
                        BorderBrush = Brushes.DimGray,
                        BorderThickness = new Thickness(0.3)
                    };
                    int iCaptured = i; 
                    int jCaptured = j;
                    border.MouseLeftButtonDown += (o, e) => CellClick(iCaptured, jCaptured);
                    cells[i, j] = border;
                    gameGrid.Children.Add(border);
                }
            }
        }
        private void UpdateVisual()
        {
            for (int i = 0; i < game.Rows; i++)
            {
                for (int j = 0;j < game.Cols; j++)
                {
                    if (game.Grid[i,j]) cells[i,j].Background = Brushes.Yellow;
                    else cells[i,j].Background = Brushes.Black;
                }
            }
        }

        private void CellClick(int row, int col)
        {
            game.ToggleCell(row, col);
            UpdateVisual();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Суп из рыбы УХА, суп из пяти рыб УХАХАХА");
            tbDebug.Text = "Button clicked";
        }
    }
}
