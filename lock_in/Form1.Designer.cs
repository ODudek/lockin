namespace lock_in
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda wsparcia projektanta - nie należy modyfikować
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.haslo = new System.Windows.Forms.Button();
            this.odblokuj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // haslo
            // 
            this.haslo.Location = new System.Drawing.Point(36, 46);
            this.haslo.Name = "haslo";
            this.haslo.Size = new System.Drawing.Size(97, 23);
            this.haslo.TabIndex = 0;
            this.haslo.Text = "Lock folder";
            this.haslo.UseVisualStyleBackColor = true;
            this.haslo.Click += new System.EventHandler(this.haslo_Click);
            // 
            // odblokuj
            // 
            this.odblokuj.Location = new System.Drawing.Point(164, 46);
            this.odblokuj.Name = "odblokuj";
            this.odblokuj.Size = new System.Drawing.Size(92, 23);
            this.odblokuj.TabIndex = 1;
            this.odblokuj.Text = "Unlock folder";
            this.odblokuj.UseVisualStyleBackColor = true;
            this.odblokuj.Click += new System.EventHandler(this.odblokuj_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 112);
            this.Controls.Add(this.odblokuj);
            this.Controls.Add(this.haslo);
            this.MaximumSize = new System.Drawing.Size(300, 150);
            this.MinimumSize = new System.Drawing.Size(300, 150);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lock folder";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button haslo;
        private System.Windows.Forms.Button odblokuj;
    }
}

