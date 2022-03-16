
namespace LibraryWinApp.Control
{
    partial class frmControl
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ts_books = new System.Windows.Forms.ToolStripButton();
            this.ts_transaction = new System.Windows.Forms.ToolStripDropDownButton();
            this.ts_BorrowItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_returnItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_overdueItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_borrower = new System.Windows.Forms.ToolStripButton();
            this.ts_categories = new System.Windows.Forms.ToolStripButton();
            this.ts_users = new System.Windows.Forms.ToolStripButton();
            this.ts_reports = new System.Windows.Forms.ToolStripButton();
            this.ts_logs = new System.Windows.Forms.ToolStripButton();
            this.ts_login = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_books,
            this.ts_transaction,
            this.ts_borrower,
            this.ts_categories,
            this.ts_users,
            this.ts_reports,
            this.ts_logs,
            this.ts_login});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 72);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ts_books
            // 
            this.ts_books.AutoSize = false;
            this.ts_books.Name = "ts_books";
            this.ts_books.Size = new System.Drawing.Size(69, 69);
            this.ts_books.Text = "Books";
            this.ts_books.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ts_transaction
            // 
            this.ts_transaction.AutoSize = false;
            this.ts_transaction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_BorrowItem,
            this.ts_returnItem,
            this.ts_overdueItem});
            this.ts_transaction.Name = "ts_transaction";
            this.ts_transaction.Size = new System.Drawing.Size(80, 69);
            this.ts_transaction.Text = "Transaction";
            this.ts_transaction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ts_BorrowItem
            // 
            this.ts_BorrowItem.Name = "ts_BorrowItem";
            this.ts_BorrowItem.Size = new System.Drawing.Size(148, 26);
            this.ts_BorrowItem.Text = "Borrow";
            // 
            // ts_returnItem
            // 
            this.ts_returnItem.Name = "ts_returnItem";
            this.ts_returnItem.Size = new System.Drawing.Size(148, 26);
            this.ts_returnItem.Text = "Return";
            // 
            // ts_overdueItem
            // 
            this.ts_overdueItem.Name = "ts_overdueItem";
            this.ts_overdueItem.Size = new System.Drawing.Size(148, 26);
            this.ts_overdueItem.Text = "Overdue";
            // 
            // ts_borrower
            // 
            this.ts_borrower.AutoSize = false;
            this.ts_borrower.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_borrower.Name = "ts_borrower";
            this.ts_borrower.Size = new System.Drawing.Size(69, 69);
            this.ts_borrower.Text = "Borrower";
            this.ts_borrower.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ts_categories
            // 
            this.ts_categories.AutoSize = false;
            this.ts_categories.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_categories.Name = "ts_categories";
            this.ts_categories.Size = new System.Drawing.Size(69, 69);
            this.ts_categories.Text = "Categories";
            this.ts_categories.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ts_users
            // 
            this.ts_users.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_users.Name = "ts_users";
            this.ts_users.Size = new System.Drawing.Size(106, 69);
            this.ts_users.Text = "Manage Users";
            this.ts_users.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ts_reports
            // 
            this.ts_reports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_reports.Name = "ts_reports";
            this.ts_reports.Size = new System.Drawing.Size(129, 69);
            this.ts_reports.Text = "Inventory Reports";
            this.ts_reports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ts_logs
            // 
            this.ts_logs.AutoSize = false;
            this.ts_logs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_logs.Name = "ts_logs";
            this.ts_logs.Size = new System.Drawing.Size(69, 69);
            this.ts_logs.Text = "User Logs";
            this.ts_logs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ts_login
            // 
            this.ts_login.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ts_login.AutoSize = false;
            this.ts_login.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_login.Name = "ts_login";
            this.ts_login.Size = new System.Drawing.Size(70, 69);
            this.ts_login.Text = "Login";
            this.ts_login.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // frmControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmControl";
            this.Text = "frmControl";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ts_books;
        private System.Windows.Forms.ToolStripDropDownButton ts_transaction;
        private System.Windows.Forms.ToolStripMenuItem ts_BorrowItem;
        private System.Windows.Forms.ToolStripMenuItem ts_returnItem;
        private System.Windows.Forms.ToolStripMenuItem ts_overdueItem;
        private System.Windows.Forms.ToolStripButton ts_borrower;
        private System.Windows.Forms.ToolStripButton ts_categories;
        private System.Windows.Forms.ToolStripButton ts_users;
        private System.Windows.Forms.ToolStripButton ts_reports;
        private System.Windows.Forms.ToolStripButton ts_logs;
        private System.Windows.Forms.ToolStripButton ts_login;
    }
}