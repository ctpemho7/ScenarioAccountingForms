
namespace ScenarioAccountingForms
{
    partial class CRUDScenario
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
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewAtomCond = new System.Windows.Forms.DataGridView();
            this.labelCond = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewThen = new System.Windows.Forms.DataGridView();
            this.dataGridViewElse = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.удалитьЭлементToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьЭлементToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьНовыйЭлементToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAtomCond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewThen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewElse)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewMain.Location = new System.Drawing.Point(12, 105);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.RowHeadersWidth = 51;
            this.dataGridViewMain.RowTemplate.Height = 24;
            this.dataGridViewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMain.Size = new System.Drawing.Size(612, 534);
            this.dataGridViewMain.TabIndex = 0;
            this.dataGridViewMain.SelectionChanged += new System.EventHandler(this.dataGridViewMain_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьToolStripMenuItem,
            this.toolStripSeparator1,
            this.изменитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 58);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(144, 6);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(651, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Правило сценария:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(651, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "ЕСЛИ";
            // 
            // dataGridViewAtomCond
            // 
            this.dataGridViewAtomCond.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAtomCond.Location = new System.Drawing.Point(651, 105);
            this.dataGridViewAtomCond.Name = "dataGridViewAtomCond";
            this.dataGridViewAtomCond.RowHeadersWidth = 51;
            this.dataGridViewAtomCond.RowTemplate.Height = 24;
            this.dataGridViewAtomCond.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAtomCond.Size = new System.Drawing.Size(740, 150);
            this.dataGridViewAtomCond.TabIndex = 3;
            // 
            // labelCond
            // 
            this.labelCond.AutoSize = true;
            this.labelCond.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCond.Location = new System.Drawing.Point(720, 80);
            this.labelCond.Name = "labelCond";
            this.labelCond.Size = new System.Drawing.Size(97, 22);
            this.labelCond.TabIndex = 4;
            this.labelCond.Text = "cond string";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(647, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "ТО";
            // 
            // dataGridViewThen
            // 
            this.dataGridViewThen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewThen.Location = new System.Drawing.Point(651, 297);
            this.dataGridViewThen.Name = "dataGridViewThen";
            this.dataGridViewThen.RowHeadersWidth = 51;
            this.dataGridViewThen.RowTemplate.Height = 24;
            this.dataGridViewThen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewThen.Size = new System.Drawing.Size(740, 150);
            this.dataGridViewThen.TabIndex = 6;
            // 
            // dataGridViewElse
            // 
            this.dataGridViewElse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewElse.Location = new System.Drawing.Point(651, 489);
            this.dataGridViewElse.Name = "dataGridViewElse";
            this.dataGridViewElse.RowHeadersWidth = 51;
            this.dataGridViewElse.RowTemplate.Height = 24;
            this.dataGridViewElse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewElse.Size = new System.Drawing.Size(740, 150);
            this.dataGridViewElse.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(647, 464);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "ИНАЧЕ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьЭлементToolStripMenuItem,
            this.изменитьЭлементToolStripMenuItem,
            this.добавитьНовыйЭлементToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1409, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // удалитьЭлементToolStripMenuItem
            // 
            this.удалитьЭлементToolStripMenuItem.Name = "удалитьЭлементToolStripMenuItem";
            this.удалитьЭлементToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.удалитьЭлементToolStripMenuItem.Text = "Удалить элемент";
            // 
            // изменитьЭлементToolStripMenuItem
            // 
            this.изменитьЭлементToolStripMenuItem.Name = "изменитьЭлементToolStripMenuItem";
            this.изменитьЭлементToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.изменитьЭлементToolStripMenuItem.Text = "Изменить элемент";
            // 
            // добавитьНовыйЭлементToolStripMenuItem
            // 
            this.добавитьНовыйЭлементToolStripMenuItem.Name = "добавитьНовыйЭлементToolStripMenuItem";
            this.добавитьНовыйЭлементToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.добавитьНовыйЭлементToolStripMenuItem.Text = "Добавить новый элемент..";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Выберите сценарий:";
            // 
            // CRUDScenario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1409, 663);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridViewElse);
            this.Controls.Add(this.dataGridViewThen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelCond);
            this.Controls.Add(this.dataGridViewAtomCond);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewMain);
            this.Name = "CRUDScenario";
            this.Text = "Изменение сценариев";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAtomCond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewThen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewElse)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewAtomCond;
        private System.Windows.Forms.Label labelCond;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewThen;
        private System.Windows.Forms.DataGridView dataGridViewElse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьНовыйЭлементToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьЭлементToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьЭлементToolStripMenuItem;
        private System.Windows.Forms.Label label3;
    }
}