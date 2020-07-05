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
using rPartidas_Juego.UI.Registros;
using rPartidas_Juego.UI.Consultas;

namespace rPartidas_Juego
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rPartidaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rPartidas rPartidas = new rPartidas();
            rPartidas.Show();
        }

        private void cJugadasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cJugadas cJugadas = new cJugadas();
            cJugadas.Show();
        }
    }
}