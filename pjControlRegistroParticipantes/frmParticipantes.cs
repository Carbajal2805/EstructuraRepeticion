namespace pjControlRegistroParticipantes
{
    public partial class frmParticipantes : Form
    {
        int num;
        int cJefe, cOperario, cAdministrativo, cPracticante;
        public frmParticipantes()
        {
            InitializeComponent();
            tHora.Enabled = true;
        }

        private void frmParticipantes_Load(object sender, EventArgs e)
        {
            num++;
            lblFecha.Text = DateTime.Now.ToString("d");
            lblNumero.Text = num.ToString("D4");
        }

        private void tHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Capturando los datos
            DateTime fecha, hora;
            string participante, cargo;
            int numero;
            participante = txtParticipantes.Text;
            numero = int.Parse(lblNumero.Text);
            fecha = DateTime.Parse(lblFecha.Text);
            hora = DateTime.Parse(lblHora.Text);
            cargo = cboCargo.Text;
            //Contabilizar la cantidad segun los cargos 
            switch (cargo)
            {
                case "Jefe": cJefe++; break;
                case "Operario": cOperario++; break;
                case "Administrativo": cAdministrativo++; break;
                case "Practicante ": cPracticante++; break;
            }
            //Imprimiendo el Registro
            ListViewItem fila = new ListViewItem(numero.ToString());
            fila.SubItems.Add(participante);
            fila.SubItems.Add(cargo);
            fila.SubItems.Add(fecha.ToString("d"));
            fila.SubItems.Add(hora.ToString("hh:mm:ss"));
            lvParticipantes.Items.Add(fila);
            //  imprimiendo lAS estadisticas
            lvEstadisticas.Items.Clear();
            string[] elementosFila = new string[2];
            ListViewItem row;
            //Añadimos la primera fila lvESTADISTICO
            elementosFila[0] = "Jefe";
            elementosFila[1] = cJefe.ToString();
            row = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);
            //Añadimos la segnda fila en lvEstadistico
            elementosFila[0] = "Operario";
            elementosFila[1]=cOperario.ToString();
            row =new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);
            //aÑADIMOS TERCERA FILA LVestadistica
            elementosFila[0] = "Administrativo";
            elementosFila[1]= cAdministrativo.ToString();
            row = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);
            //añadimos cuarta fila 
            elementosFila[0] = "´Practicante ";
            elementosFila[1]= cPracticante.ToString();
            row = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);
            //MOSTRANDO EL NUEVO NUMERO DE REGISTRO
            num++;
            lblNumero.Text = num.ToString("D4");
            //Limpiando controles 
            txtParticipantes.Clear();
            cboCargo.SelectedIndex = -1;
            txtParticipantes.Focus();

        


        }
    }
}