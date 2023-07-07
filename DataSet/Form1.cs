using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSet
{
    public partial class Form1 : Form
    {
        DataRow dr;
        DataRow[] dra;
        public Form1()
        {
            InitializeComponent();
        }

        private void usuarioBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usuarioBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'database1DataSet.Usuario' Puede moverla o quitarla según sea necesario.
            this.usuarioTableAdapter.Fill(this.database1DataSet.Usuario);

        }

        private void bt_nuevo_Click(object sender, EventArgs e)
        {
            tb_id.Clear();
            tb_nombre.Clear();
            tb_edad.Clear();
            dr = database1DataSet.Tables[0].NewRow();
            
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            dr["Nombre"] = tb_nombre.Text;
            dr["Id"] = tb_id.Text;
            dr["Edad"] = tb_edad.Text;
            dr["Activo"] = cb_activo.Checked;
            database1DataSet.Tables[0].Rows.Add(dr);

            this.Validate();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);
        }

        private void bt_buscar_Click(object sender, EventArgs e)
        {
            String filtro = "Id = '" + tb_claveBuscar.Text + "'";
            dra = database1DataSet.Tables[0].Select(filtro);
            if(dra.Count() > 0)
            {
                tb_id.Text = dra[0].ItemArray[0].ToString();
                tb_nombre.Text = dra[0].ItemArray[1].ToString();
                tb_edad.Text = dra[0].ItemArray[2].ToString();
            }
        }

        private void bt_borrar_Click(object sender, EventArgs e)
        {
            int clave = int.Parse(tb_claveBuscar.Text);
            dr = database1DataSet.Tables[0].Rows.Find(clave);
            if(dr != null)
            {
                dr.Delete();
                this.Validate();
                this.tableAdapterManager.UpdateAll(this.database1DataSet);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int clave = int.Parse(tb_id.Text);
            dr = database1DataSet.Tables[0].Rows.Find(clave);
            if (dr != null)
            {
                dr.BeginEdit();

                dr["Nombre"] = tb_nombre.Text;
                dr["Id"] = tb_id.Text;
                dr["Edad"] = tb_edad.Text;
                dr["Activo"] = cb_activo.Checked;

                dr.EndEdit();
            }
        }

        private void bt_guardar_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);
        }
    }
}
