using rPartidas_Juego.BLL;
using rPartidas_Juego.Entidades;
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

namespace rPartidas_Juego.UI.Registros
{
    public partial class rPartidas : Window
    {
        private Partidas partidas = new Partidas();
        public rPartidas()
        {
            InitializeComponent();
            this.DataContext = partidas;

            //——————————————————————————[ VALORES DEL ComboBox ]——————————————————————————
            JugadoresComboBox.SelectedValuePath = "JugadorId";
            JugadoresComboBox.DisplayMemberPath = "Nombres";
            JugadoresComboBox.ItemsSource = JugadoresBLL.GetList();
        }
        //—————————————————————————————————————————————————————[ CARGAR ]—————————————————————————————————————————————————————
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = partidas;
        }
        //—————————————————————————————————————————————————————[ LIMPIAR ]—————————————————————————————————————————————————————
        private void Limpiar()
        {
            this.partidas = new Partidas();
            this.DataContext = partidas;
        }
        //—————————————————————————————————————————————————————[ Validar ]—————————————————————————————————————————————————————
        private bool Validar()
        {
            bool Validado = true;
            if (IdTextbox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transaccion Errada", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return Validado;
        }
        //—————————————————————————————————————————————————————[ BUSCAR ]—————————————————————————————————————————————————————
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Partidas encontrado = PartidasBLL.Buscar(partidas.PartidaId);

            if (encontrado != null)
            {
                partidas = encontrado;
                Cargar();
                MessageBox.Show("Partida Encontrada", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"La Id de Partida no fue encontrada.\n\nAsegurese que existe o cree una nueva.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
            }
        }
        //—————————————————————————————————————————————————————[ AGREGAR FILA ]—————————————————————————————————————————————————————
        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            var filaDetalle = new PartidasDetalle
            {
                PartidaId = this.partidas.PartidaId,
                JugadorId = Utilidades.ToInt(JugadoresComboBox.SelectedValue.ToString()),
                Posicion = Utilidades.ToInt(PosicionTextBox.Text)
            };

            //Todo: Evitar que se agrege el mismo jugador 2 veces.
            this.partidas.Detalle.Add(filaDetalle);
            Cargar();

            JugadoresComboBox.SelectedIndex = -1;
            PosicionTextBox.Clear();
        }
        //—————————————————————————————————————————————————————[ REMOVER FILA ]—————————————————————————————————————————————————————
        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                partidas.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }
        //—————————————————————————————————————————————————————[ NUEVO ]—————————————————————————————————————————————————————
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        //—————————————————————————————————————————————————————[ GUARDAR ]—————————————————————————————————————————————————————
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                var paso = PartidasBLL.Guardar(this.partidas);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transaccion Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Errada", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //—————————————————————————————————————————————————————[ ELIMINAR ]—————————————————————————————————————————————————————
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (PartidasBLL.Eliminar(Utilidades.ToInt(IdTextbox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
