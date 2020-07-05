using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using rPartidas_Juego.BLL;
using rPartidas_Juego.Entidades;
using static rPartidas_Juego.UI.Registros.rPartidas;

namespace rPartidas_Juego.UI.Consultas
{
    public partial class cJugadas : Window
    {
        public cJugadas()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            List<Partidas> listado = new List<Partidas>();
            
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = PartidasBLL.GetList(p => p.PartidaId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                    case 1:
                        listado = PartidasBLL.GetList(p => p.Descripcion.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                }
            }
            else
            {
                listado = PartidasBLL.GetList(c => true);
            }
            if (DesdeDatePicker.SelectedDate != null)
                listado = (List<Partidas>)PartidasBLL.GetList(p => p.Fecha.Date >= DesdeDatePicker.SelectedDate);
            if (HastaDatePicker.SelectedDate != null)
                listado = (List<Partidas>)PartidasBLL.GetList(p => p.Fecha.Date <= HastaDatePicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}