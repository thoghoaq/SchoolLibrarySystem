
namespace LibraryWinApp
{
    partial class frmBorrowManager
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
            this.dgvBorrowList = new System.Windows.Forms.DataGridView();
            this.dgvBorrowNotReturn = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowNotReturn)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBorrowList
            // 
            this.dgvBorrowList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrowList.Location = new System.Drawing.Point(30, 33);
            this.dgvBorrowList.Name = "dgvBorrowList";
            this.dgvBorrowList.RowHeadersWidth = 51;
            this.dgvBorrowList.RowTemplate.Height = 29;
            this.dgvBorrowList.Size = new System.Drawing.Size(1016, 207);
            this.dgvBorrowList.TabIndex = 0;
            this.dgvBorrowList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBorrowList_CellContentClick);
            // 
            // dgvBorrowNotReturn
            // 
            this.dgvBorrowNotReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrowNotReturn.Location = new System.Drawing.Point(30, 283);
            this.dgvBorrowNotReturn.Name = "dgvBorrowNotReturn";
            this.dgvBorrowNotReturn.RowHeadersWidth = 51;
            this.dgvBorrowNotReturn.RowTemplate.Height = 29;
            this.dgvBorrowNotReturn.Size = new System.Drawing.Size(1016, 221);
            this.dgvBorrowNotReturn.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Borrow has Returned";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Borrow has Not Return Yet";
            // 
            // frmBorrowManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 516);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBorrowNotReturn);
            this.Controls.Add(this.dgvBorrowList);
            this.Name = "frmBorrowManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Borrow History";
            this.Load += new System.EventHandler(this.frmBorrowManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowNotReturn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBorrowList;
        private System.Windows.Forms.DataGridView dgvBorrowNotReturn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}