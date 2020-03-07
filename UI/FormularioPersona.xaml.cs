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
using PuntosExtras.BLL;
using PuntosExtras.Entidades;

namespace PuntosExtras.UI
{
    /// <summary>
    /// Lógica de interacción para FormularioPersona.xaml
    /// </summary>
    public partial class FormularioPersona : Window
    {
        public FormularioPersona()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            PersonaIDTextBox.Text = "0";
            NombreTextBox.Text = string.Empty;
        }

        private Personas LlenaClase()
        {
            Personas persona = new Personas();

            persona.PersonaId = int.Parse(PersonaIDTextBox.Text);
            persona.Nombre = NombreTextBox.Text;

            return persona;
        }

        private void LlenaCampo(Personas persona)
        {
            PersonaIDTextBox.Text = Convert.ToString(persona.PersonaId);
            NombreTextBox.Text = persona.Nombre;
        }

        private bool ExisteEnDb()
        {
            Personas persona = PersonasBLL.Buscar(int.Parse(PersonaIDTextBox.Text));
            return (persona != null);
        }

        private bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrEmpty(NombreTextBox.Text))
            {
                MessageBox.Show("el campo nombre no puede esta vacio");
                NombreTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(PersonaIDTextBox.Text, out id);
            Personas persona = new Personas();

            persona = PersonasBLL.Buscar(id);
            if (persona != null)
            {
                LlenaCampo(persona);
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(PersonaIDTextBox.Text, out id);

            if (PersonasBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado!!!");
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            bool paso = false;
            Personas persona;
            if (!Validar())
                return;

            persona = LlenaClase();
            if (string.IsNullOrEmpty(PersonaIDTextBox.Text) || PersonaIDTextBox.Text == "0")
                paso = PersonasBLL.Guardar(persona);
            else
            {
                if (!ExisteEnDb())
                {
                    MessageBox.Show("Error");
                    return;
                }
                paso = PersonasBLL.Modificar(persona);
            }

            if (paso)
            {
                MessageBox.Show("Guardado");
                Limpiar();
            }
            else
            {
                MessageBox.Show("Guardado");
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
    }
}
