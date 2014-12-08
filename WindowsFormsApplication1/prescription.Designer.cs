namespace WindowsFormsApplication1
{
    partial class prescription
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.inside_470DataSet = new WindowsFormsApplication1.inside_470DataSet();
            this.docinfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.doc_infoTableAdapter = new WindowsFormsApplication1.inside_470DataSetTableAdapters.doc_infoTableAdapter();
            this.druginfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.drug_infoTableAdapter = new WindowsFormsApplication1.inside_470DataSetTableAdapters.drug_infoTableAdapter();
            this.inside470DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.docinfoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.druginfoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.drugIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.druginfoBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inside_470DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docinfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.druginfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inside470DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docinfoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.druginfoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.druginfoBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transaction_ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Auto_Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Patient_id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "P_id";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Doc_id";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(145, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "D id";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(397, 24);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(161, 96);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(297, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Prescription";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(300, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Charge";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(397, 170);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "date";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Save it to patient profile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(422, 382);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Check Out";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // inside_470DataSet
            // 
            this.inside_470DataSet.DataSetName = "inside_470DataSet";
            this.inside_470DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // docinfoBindingSource
            // 
            this.docinfoBindingSource.DataMember = "doc_info";
            this.docinfoBindingSource.DataSource = this.inside_470DataSet;
            // 
            // doc_infoTableAdapter
            // 
            this.doc_infoTableAdapter.ClearBeforeFill = true;
            // 
            // druginfoBindingSource
            // 
            this.druginfoBindingSource.DataMember = "drug_info";
            this.druginfoBindingSource.DataSource = this.inside_470DataSet;
            // 
            // drug_infoTableAdapter
            // 
            this.drug_infoTableAdapter.ClearBeforeFill = true;
            // 
            // inside470DataSetBindingSource
            // 
            this.inside470DataSetBindingSource.DataSource = this.inside_470DataSet;
            this.inside470DataSetBindingSource.Position = 0;
            // 
            // docinfoBindingSource1
            // 
            this.docinfoBindingSource1.DataMember = "doc_info";
            this.docinfoBindingSource1.DataSource = this.inside470DataSetBindingSource;
            // 
            // druginfoBindingSource1
            // 
            this.druginfoBindingSource1.DataMember = "drug_info";
            this.druginfoBindingSource1.DataSource = this.inside470DataSetBindingSource;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.drugIdDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.druginfoBindingSource2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 210);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(409, 150);
            this.dataGridView1.TabIndex = 19;
            // 
            // drugIdDataGridViewTextBoxColumn
            // 
            this.drugIdDataGridViewTextBoxColumn.DataPropertyName = "drug_Id";
            this.drugIdDataGridViewTextBoxColumn.HeaderText = "drug_Id";
            this.drugIdDataGridViewTextBoxColumn.Name = "drugIdDataGridViewTextBoxColumn";
            this.drugIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // druginfoBindingSource2
            // 
            this.druginfoBindingSource2.DataMember = "drug_info";
            this.druginfoBindingSource2.DataSource = this.inside_470DataSet;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(439, 210);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Search for drug";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(442, 235);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 21;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(73, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "label11";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(442, 287);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "show transaction";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // prescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 431);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "prescription";
            this.Text = "prescription";
            this.Load += new System.EventHandler(this.prescription_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inside_470DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docinfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.druginfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inside470DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docinfoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.druginfoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.druginfoBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private inside_470DataSet inside_470DataSet;
        private System.Windows.Forms.BindingSource docinfoBindingSource;
        private inside_470DataSetTableAdapters.doc_infoTableAdapter doc_infoTableAdapter;
        private System.Windows.Forms.BindingSource druginfoBindingSource;
        private inside_470DataSetTableAdapters.drug_infoTableAdapter drug_infoTableAdapter;
        private System.Windows.Forms.BindingSource inside470DataSetBindingSource;
        private System.Windows.Forms.BindingSource docinfoBindingSource1;
        private System.Windows.Forms.BindingSource druginfoBindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn drugIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource druginfoBindingSource2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button3;
    }
}