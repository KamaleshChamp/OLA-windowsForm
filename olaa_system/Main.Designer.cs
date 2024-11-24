
namespace olaa_system
{
    partial class Main
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
            this.car = new System.Windows.Forms.Button();
            this.customer = new System.Windows.Forms.Button();
            this.rental = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // car
            // 
            this.car.BackColor = System.Drawing.Color.Blue;
            this.car.Font = new System.Drawing.Font("Castellar", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.car.ForeColor = System.Drawing.Color.White;
            this.car.Location = new System.Drawing.Point(224, 119);
            this.car.Name = "car";
            this.car.Size = new System.Drawing.Size(286, 47);
            this.car.TabIndex = 10;
            this.car.Text = "Car Resgistration";
            this.car.UseVisualStyleBackColor = false;
            this.car.Click += new System.EventHandler(this.car_Click);
            // 
            // customer
            // 
            this.customer.BackColor = System.Drawing.Color.Blue;
            this.customer.Font = new System.Drawing.Font("Castellar", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customer.ForeColor = System.Drawing.Color.White;
            this.customer.Location = new System.Drawing.Point(224, 220);
            this.customer.Name = "customer";
            this.customer.Size = new System.Drawing.Size(286, 41);
            this.customer.TabIndex = 11;
            this.customer.Text = "Customer";
            this.customer.UseVisualStyleBackColor = false;
            this.customer.Click += new System.EventHandler(this.customer_Click);
            // 
            // rental
            // 
            this.rental.BackColor = System.Drawing.Color.Blue;
            this.rental.Font = new System.Drawing.Font("Castellar", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rental.ForeColor = System.Drawing.Color.White;
            this.rental.Location = new System.Drawing.Point(224, 310);
            this.rental.Name = "rental";
            this.rental.Size = new System.Drawing.Size(286, 43);
            this.rental.TabIndex = 12;
            this.rental.Text = "BOOKING";
            this.rental.UseVisualStyleBackColor = false;
            this.rental.Click += new System.EventHandler(this.rental_Click);
            // 
            // logout
            // 
            this.logout.BackColor = System.Drawing.Color.Blue;
            this.logout.Font = new System.Drawing.Font("Castellar", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout.ForeColor = System.Drawing.Color.White;
            this.logout.Location = new System.Drawing.Point(224, 423);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(296, 39);
            this.logout.TabIndex = 14;
            this.logout.Text = "Logout";
            this.logout.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(218, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 34);
            this.label1.TabIndex = 15;
            this.label1.Text = "WELCOME TO OLA";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 630);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.rental);
            this.Controls.Add(this.customer);
            this.Controls.Add(this.car);
            this.ForeColor = System.Drawing.Color.Blue;
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button car;
        private System.Windows.Forms.Button customer;
        private System.Windows.Forms.Button rental;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Label label1;
    }
}