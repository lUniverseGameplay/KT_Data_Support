namespace KT_Data_Support_main
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox_Teams = new System.Windows.Forms.ListBox();
            this.listBox_Operatives = new System.Windows.Forms.ListBox();
            this.weapons_table_header = new System.Windows.Forms.Label();
            this.listBox_Weapons = new System.Windows.Forms.ListBox();
            this.ops_table_header = new System.Windows.Forms.Label();
            this.teams_table_header = new System.Windows.Forms.Label();
            this.Full_output_weapon_box = new System.Windows.Forms.GroupBox();
            this.Full_output_weapon_rules_header = new System.Windows.Forms.Label();
            this.Full_output_weapon_rules_box = new System.Windows.Forms.ListBox();
            this.Full_output_weapon_damage = new System.Windows.Forms.Label();
            this.Full_output_weapon_hit = new System.Windows.Forms.Label();
            this.Full_output_weapon_attack = new System.Windows.Forms.Label();
            this.Full_output_weapon_name = new System.Windows.Forms.Label();
            this.Full_output_weapon_type = new System.Windows.Forms.Label();
            this.Full_output_weapon_team_name = new System.Windows.Forms.Label();
            this.Full_output_weapon_ID = new System.Windows.Forms.Label();
            this.Full_output_weapon_name_label = new System.Windows.Forms.Label();
            this.Full_output_operative_box = new System.Windows.Forms.GroupBox();
            this.Full_output_operative_wounds = new System.Windows.Forms.Label();
            this.Full_output_operative_save = new System.Windows.Forms.Label();
            this.Full_output_operative_move = new System.Windows.Forms.Label();
            this.Full_output_operative_apl = new System.Windows.Forms.Label();
            this.Full_output_operative_name = new System.Windows.Forms.Label();
            this.Full_output_operative_team_name = new System.Windows.Forms.Label();
            this.Full_output_operative_ID = new System.Windows.Forms.Label();
            this.Full_output_operative_name_label = new System.Windows.Forms.Label();
            this.Rule_description = new System.Windows.Forms.Label();
            this.Rule_description_header = new System.Windows.Forms.Label();
            this.Full_output_operative_weapons_header = new System.Windows.Forms.Label();
            this.Full_output_operative_weapons_box = new System.Windows.Forms.ListBox();
            this.Full_output_operative_abilities_box = new System.Windows.Forms.ListBox();
            this.Full_output_operative_abilities_header = new System.Windows.Forms.Label();
            this.Full_output_operative_keywords = new System.Windows.Forms.Label();
            this.Full_output_team_box = new System.Windows.Forms.GroupBox();
            this.Full_output_team_name = new System.Windows.Forms.Label();
            this.Full_output_team_ID = new System.Windows.Forms.Label();
            this.Full_output_team_name_label = new System.Windows.Forms.Label();
            this.Full_output_team_rules_header = new System.Windows.Forms.Label();
            this.Full_output_team_rules_box = new System.Windows.Forms.ListBox();
            this.Full_output_team_stratagem_box = new System.Windows.Forms.ListBox();
            this.Full_output_team_stratagem_header = new System.Windows.Forms.Label();
            this.Full_output_team_equipment_box = new System.Windows.Forms.ListBox();
            this.Full_output_team_equipment_header = new System.Windows.Forms.Label();
            this.Full_output_team_datacards_box = new System.Windows.Forms.ListBox();
            this.Full_output_team_datacards_header = new System.Windows.Forms.Label();
            this.Full_output_team_archetypes = new System.Windows.Forms.Label();
            this.Full_output_weapon_box.SuspendLayout();
            this.Full_output_operative_box.SuspendLayout();
            this.Full_output_team_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_Teams
            // 
            this.listBox_Teams.FormattingEnabled = true;
            this.listBox_Teams.Location = new System.Drawing.Point(520, 49);
            this.listBox_Teams.Name = "listBox_Teams";
            this.listBox_Teams.Size = new System.Drawing.Size(200, 95);
            this.listBox_Teams.TabIndex = 0;
            this.listBox_Teams.SelectedIndexChanged += new System.EventHandler(this.listBox_Teams_SelectedIndexChanged);
            // 
            // listBox_Operatives
            // 
            this.listBox_Operatives.FormattingEnabled = true;
            this.listBox_Operatives.Location = new System.Drawing.Point(520, 187);
            this.listBox_Operatives.Name = "listBox_Operatives";
            this.listBox_Operatives.Size = new System.Drawing.Size(200, 95);
            this.listBox_Operatives.TabIndex = 2;
            this.listBox_Operatives.SelectedIndexChanged += new System.EventHandler(this.listBox_Operatives_SelectedIndexChanged);
            // 
            // weapons_table_header
            // 
            this.weapons_table_header.BackColor = System.Drawing.Color.Silver;
            this.weapons_table_header.Location = new System.Drawing.Point(520, 290);
            this.weapons_table_header.Name = "weapons_table_header";
            this.weapons_table_header.Size = new System.Drawing.Size(200, 30);
            this.weapons_table_header.TabIndex = 5;
            this.weapons_table_header.Text = "Weapons table";
            this.weapons_table_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox_Weapons
            // 
            this.listBox_Weapons.FormattingEnabled = true;
            this.listBox_Weapons.Location = new System.Drawing.Point(520, 323);
            this.listBox_Weapons.Name = "listBox_Weapons";
            this.listBox_Weapons.Size = new System.Drawing.Size(200, 134);
            this.listBox_Weapons.TabIndex = 4;
            this.listBox_Weapons.SelectedIndexChanged += new System.EventHandler(this.listBox_Weapons_SelectedIndexChanged);
            // 
            // ops_table_header
            // 
            this.ops_table_header.BackColor = System.Drawing.Color.Silver;
            this.ops_table_header.Location = new System.Drawing.Point(520, 154);
            this.ops_table_header.Name = "ops_table_header";
            this.ops_table_header.Size = new System.Drawing.Size(200, 30);
            this.ops_table_header.TabIndex = 6;
            this.ops_table_header.Text = "Operatives table";
            this.ops_table_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // teams_table_header
            // 
            this.teams_table_header.BackColor = System.Drawing.Color.Silver;
            this.teams_table_header.Location = new System.Drawing.Point(520, 16);
            this.teams_table_header.Name = "teams_table_header";
            this.teams_table_header.Size = new System.Drawing.Size(200, 30);
            this.teams_table_header.TabIndex = 7;
            this.teams_table_header.Text = "Teams table";
            this.teams_table_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Full_output_weapon_box
            // 
            this.Full_output_weapon_box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_weapon_box.Controls.Add(this.Full_output_weapon_rules_header);
            this.Full_output_weapon_box.Controls.Add(this.Full_output_weapon_rules_box);
            this.Full_output_weapon_box.Controls.Add(this.Full_output_weapon_damage);
            this.Full_output_weapon_box.Controls.Add(this.Full_output_weapon_hit);
            this.Full_output_weapon_box.Controls.Add(this.Full_output_weapon_attack);
            this.Full_output_weapon_box.Controls.Add(this.Full_output_weapon_name);
            this.Full_output_weapon_box.Controls.Add(this.Full_output_weapon_type);
            this.Full_output_weapon_box.Controls.Add(this.Full_output_weapon_team_name);
            this.Full_output_weapon_box.Controls.Add(this.Full_output_weapon_ID);
            this.Full_output_weapon_box.Controls.Add(this.Full_output_weapon_name_label);
            this.Full_output_weapon_box.Location = new System.Drawing.Point(772, 12);
            this.Full_output_weapon_box.Name = "Full_output_weapon_box";
            this.Full_output_weapon_box.Size = new System.Drawing.Size(300, 445);
            this.Full_output_weapon_box.TabIndex = 8;
            this.Full_output_weapon_box.TabStop = false;
            this.Full_output_weapon_box.Text = "Full view";
            // 
            // Full_output_weapon_rules_header
            // 
            this.Full_output_weapon_rules_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_weapon_rules_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_weapon_rules_header.Location = new System.Drawing.Point(6, 267);
            this.Full_output_weapon_rules_header.Name = "Full_output_weapon_rules_header";
            this.Full_output_weapon_rules_header.Size = new System.Drawing.Size(288, 18);
            this.Full_output_weapon_rules_header.TabIndex = 17;
            this.Full_output_weapon_rules_header.Text = "Weapon rules: ";
            this.Full_output_weapon_rules_header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_weapon_rules_box
            // 
            this.Full_output_weapon_rules_box.FormattingEnabled = true;
            this.Full_output_weapon_rules_box.Location = new System.Drawing.Point(6, 292);
            this.Full_output_weapon_rules_box.Name = "Full_output_weapon_rules_box";
            this.Full_output_weapon_rules_box.Size = new System.Drawing.Size(288, 147);
            this.Full_output_weapon_rules_box.TabIndex = 12;
            this.Full_output_weapon_rules_box.SelectedIndexChanged += new System.EventHandler(this.Full_output_weapon_rules_box_SelectedIndexChanged);
            // 
            // Full_output_weapon_damage
            // 
            this.Full_output_weapon_damage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_weapon_damage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_weapon_damage.Location = new System.Drawing.Point(6, 234);
            this.Full_output_weapon_damage.Name = "Full_output_weapon_damage";
            this.Full_output_weapon_damage.Size = new System.Drawing.Size(288, 18);
            this.Full_output_weapon_damage.TabIndex = 16;
            this.Full_output_weapon_damage.Text = "Damage: x/x";
            this.Full_output_weapon_damage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_weapon_hit
            // 
            this.Full_output_weapon_hit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_weapon_hit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_weapon_hit.Location = new System.Drawing.Point(6, 201);
            this.Full_output_weapon_hit.Name = "Full_output_weapon_hit";
            this.Full_output_weapon_hit.Size = new System.Drawing.Size(288, 18);
            this.Full_output_weapon_hit.TabIndex = 15;
            this.Full_output_weapon_hit.Text = "Hit stat: ";
            this.Full_output_weapon_hit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_weapon_attack
            // 
            this.Full_output_weapon_attack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_weapon_attack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_weapon_attack.Location = new System.Drawing.Point(6, 166);
            this.Full_output_weapon_attack.Name = "Full_output_weapon_attack";
            this.Full_output_weapon_attack.Size = new System.Drawing.Size(288, 18);
            this.Full_output_weapon_attack.TabIndex = 14;
            this.Full_output_weapon_attack.Text = "Attack stat: ";
            this.Full_output_weapon_attack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_weapon_name
            // 
            this.Full_output_weapon_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_weapon_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_weapon_name.Location = new System.Drawing.Point(6, 133);
            this.Full_output_weapon_name.Name = "Full_output_weapon_name";
            this.Full_output_weapon_name.Size = new System.Drawing.Size(288, 18);
            this.Full_output_weapon_name.TabIndex = 13;
            this.Full_output_weapon_name.Text = "Name: ";
            this.Full_output_weapon_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_weapon_type
            // 
            this.Full_output_weapon_type.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_weapon_type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_weapon_type.Location = new System.Drawing.Point(6, 105);
            this.Full_output_weapon_type.Name = "Full_output_weapon_type";
            this.Full_output_weapon_type.Size = new System.Drawing.Size(288, 18);
            this.Full_output_weapon_type.TabIndex = 12;
            this.Full_output_weapon_type.Text = "Type: ";
            this.Full_output_weapon_type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_weapon_team_name
            // 
            this.Full_output_weapon_team_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_weapon_team_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_weapon_team_name.Location = new System.Drawing.Point(6, 76);
            this.Full_output_weapon_team_name.Name = "Full_output_weapon_team_name";
            this.Full_output_weapon_team_name.Size = new System.Drawing.Size(288, 18);
            this.Full_output_weapon_team_name.TabIndex = 11;
            this.Full_output_weapon_team_name.Text = "Team name: ";
            this.Full_output_weapon_team_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_weapon_ID
            // 
            this.Full_output_weapon_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_weapon_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_weapon_ID.Location = new System.Drawing.Point(6, 48);
            this.Full_output_weapon_ID.Name = "Full_output_weapon_ID";
            this.Full_output_weapon_ID.Size = new System.Drawing.Size(288, 18);
            this.Full_output_weapon_ID.TabIndex = 10;
            this.Full_output_weapon_ID.Text = "ID: ";
            this.Full_output_weapon_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_weapon_name_label
            // 
            this.Full_output_weapon_name_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Full_output_weapon_name_label.Location = new System.Drawing.Point(6, 16);
            this.Full_output_weapon_name_label.Name = "Full_output_weapon_name_label";
            this.Full_output_weapon_name_label.Size = new System.Drawing.Size(288, 18);
            this.Full_output_weapon_name_label.TabIndex = 9;
            this.Full_output_weapon_name_label.Text = "Weapon characteristics";
            this.Full_output_weapon_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Full_output_operative_box
            // 
            this.Full_output_operative_box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_operative_box.Controls.Add(this.Full_output_operative_keywords);
            this.Full_output_operative_box.Controls.Add(this.Full_output_operative_abilities_box);
            this.Full_output_operative_box.Controls.Add(this.Full_output_operative_abilities_header);
            this.Full_output_operative_box.Controls.Add(this.Full_output_operative_weapons_box);
            this.Full_output_operative_box.Controls.Add(this.Full_output_operative_weapons_header);
            this.Full_output_operative_box.Controls.Add(this.Full_output_operative_wounds);
            this.Full_output_operative_box.Controls.Add(this.Full_output_operative_save);
            this.Full_output_operative_box.Controls.Add(this.Full_output_operative_move);
            this.Full_output_operative_box.Controls.Add(this.Full_output_operative_apl);
            this.Full_output_operative_box.Controls.Add(this.Full_output_operative_name);
            this.Full_output_operative_box.Controls.Add(this.Full_output_operative_team_name);
            this.Full_output_operative_box.Controls.Add(this.Full_output_operative_ID);
            this.Full_output_operative_box.Controls.Add(this.Full_output_operative_name_label);
            this.Full_output_operative_box.Location = new System.Drawing.Point(772, 12);
            this.Full_output_operative_box.Name = "Full_output_operative_box";
            this.Full_output_operative_box.Size = new System.Drawing.Size(300, 445);
            this.Full_output_operative_box.TabIndex = 18;
            this.Full_output_operative_box.TabStop = false;
            this.Full_output_operative_box.Text = "Full view";
            // 
            // Full_output_operative_wounds
            // 
            this.Full_output_operative_wounds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_operative_wounds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_operative_wounds.Location = new System.Drawing.Point(6, 198);
            this.Full_output_operative_wounds.Name = "Full_output_operative_wounds";
            this.Full_output_operative_wounds.Size = new System.Drawing.Size(288, 18);
            this.Full_output_operative_wounds.TabIndex = 17;
            this.Full_output_operative_wounds.Text = "Wound stat: ";
            this.Full_output_operative_wounds.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_operative_save
            // 
            this.Full_output_operative_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_operative_save.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_operative_save.Location = new System.Drawing.Point(6, 173);
            this.Full_output_operative_save.Name = "Full_output_operative_save";
            this.Full_output_operative_save.Size = new System.Drawing.Size(288, 18);
            this.Full_output_operative_save.TabIndex = 16;
            this.Full_output_operative_save.Text = "Save stat: ";
            this.Full_output_operative_save.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_operative_move
            // 
            this.Full_output_operative_move.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_operative_move.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_operative_move.Location = new System.Drawing.Point(6, 148);
            this.Full_output_operative_move.Name = "Full_output_operative_move";
            this.Full_output_operative_move.Size = new System.Drawing.Size(288, 18);
            this.Full_output_operative_move.TabIndex = 15;
            this.Full_output_operative_move.Text = "Move stat: ";
            this.Full_output_operative_move.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_operative_apl
            // 
            this.Full_output_operative_apl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_operative_apl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_operative_apl.Location = new System.Drawing.Point(6, 123);
            this.Full_output_operative_apl.Name = "Full_output_operative_apl";
            this.Full_output_operative_apl.Size = new System.Drawing.Size(288, 18);
            this.Full_output_operative_apl.TabIndex = 14;
            this.Full_output_operative_apl.Text = "APL stat: ";
            this.Full_output_operative_apl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_operative_name
            // 
            this.Full_output_operative_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_operative_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_operative_name.Location = new System.Drawing.Point(6, 98);
            this.Full_output_operative_name.Name = "Full_output_operative_name";
            this.Full_output_operative_name.Size = new System.Drawing.Size(288, 18);
            this.Full_output_operative_name.TabIndex = 13;
            this.Full_output_operative_name.Text = "Name: ";
            this.Full_output_operative_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_operative_team_name
            // 
            this.Full_output_operative_team_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_operative_team_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_operative_team_name.Location = new System.Drawing.Point(6, 73);
            this.Full_output_operative_team_name.Name = "Full_output_operative_team_name";
            this.Full_output_operative_team_name.Size = new System.Drawing.Size(288, 18);
            this.Full_output_operative_team_name.TabIndex = 11;
            this.Full_output_operative_team_name.Text = "Team name: ";
            this.Full_output_operative_team_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_operative_ID
            // 
            this.Full_output_operative_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_operative_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_operative_ID.Location = new System.Drawing.Point(6, 48);
            this.Full_output_operative_ID.Name = "Full_output_operative_ID";
            this.Full_output_operative_ID.Size = new System.Drawing.Size(288, 18);
            this.Full_output_operative_ID.TabIndex = 10;
            this.Full_output_operative_ID.Text = "ID: ";
            this.Full_output_operative_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_operative_name_label
            // 
            this.Full_output_operative_name_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Full_output_operative_name_label.Location = new System.Drawing.Point(6, 16);
            this.Full_output_operative_name_label.Name = "Full_output_operative_name_label";
            this.Full_output_operative_name_label.Size = new System.Drawing.Size(288, 18);
            this.Full_output_operative_name_label.TabIndex = 9;
            this.Full_output_operative_name_label.Text = "Operative characteristics";
            this.Full_output_operative_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Rule_description
            // 
            this.Rule_description.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Rule_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Rule_description.ForeColor = System.Drawing.SystemColors.Control;
            this.Rule_description.Location = new System.Drawing.Point(520, 489);
            this.Rule_description.Name = "Rule_description";
            this.Rule_description.Size = new System.Drawing.Size(552, 68);
            this.Rule_description.TabIndex = 9;
            this.Rule_description.Text = "Описание стратагем, правил";
            this.Rule_description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Rule_description_header
            // 
            this.Rule_description_header.BackColor = System.Drawing.Color.Silver;
            this.Rule_description_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Rule_description_header.Location = new System.Drawing.Point(520, 471);
            this.Rule_description_header.Name = "Rule_description_header";
            this.Rule_description_header.Size = new System.Drawing.Size(552, 18);
            this.Rule_description_header.TabIndex = 11;
            this.Rule_description_header.Text = "Description";
            this.Rule_description_header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_operative_weapons_header
            // 
            this.Full_output_operative_weapons_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_operative_weapons_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_operative_weapons_header.Location = new System.Drawing.Point(6, 223);
            this.Full_output_operative_weapons_header.Name = "Full_output_operative_weapons_header";
            this.Full_output_operative_weapons_header.Size = new System.Drawing.Size(288, 18);
            this.Full_output_operative_weapons_header.TabIndex = 18;
            this.Full_output_operative_weapons_header.Text = "Weapons id: ";
            this.Full_output_operative_weapons_header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_operative_weapons_box
            // 
            this.Full_output_operative_weapons_box.FormattingEnabled = true;
            this.Full_output_operative_weapons_box.Location = new System.Drawing.Point(6, 244);
            this.Full_output_operative_weapons_box.Name = "Full_output_operative_weapons_box";
            this.Full_output_operative_weapons_box.Size = new System.Drawing.Size(288, 56);
            this.Full_output_operative_weapons_box.TabIndex = 18;
            // 
            // Full_output_operative_abilities_box
            // 
            this.Full_output_operative_abilities_box.FormattingEnabled = true;
            this.Full_output_operative_abilities_box.Location = new System.Drawing.Point(6, 328);
            this.Full_output_operative_abilities_box.Name = "Full_output_operative_abilities_box";
            this.Full_output_operative_abilities_box.Size = new System.Drawing.Size(288, 56);
            this.Full_output_operative_abilities_box.TabIndex = 19;
            this.Full_output_operative_abilities_box.SelectedIndexChanged += new System.EventHandler(this.Full_output_operative_abilities_box_SelectedIndexChanged);
            // 
            // Full_output_operative_abilities_header
            // 
            this.Full_output_operative_abilities_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_operative_abilities_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_operative_abilities_header.Location = new System.Drawing.Point(6, 307);
            this.Full_output_operative_abilities_header.Name = "Full_output_operative_abilities_header";
            this.Full_output_operative_abilities_header.Size = new System.Drawing.Size(288, 18);
            this.Full_output_operative_abilities_header.TabIndex = 20;
            this.Full_output_operative_abilities_header.Text = "Abilities: ";
            this.Full_output_operative_abilities_header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_operative_keywords
            // 
            this.Full_output_operative_keywords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_operative_keywords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_operative_keywords.Location = new System.Drawing.Point(6, 392);
            this.Full_output_operative_keywords.Name = "Full_output_operative_keywords";
            this.Full_output_operative_keywords.Size = new System.Drawing.Size(288, 43);
            this.Full_output_operative_keywords.TabIndex = 22;
            this.Full_output_operative_keywords.Text = "Keywords: ";
            this.Full_output_operative_keywords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_team_box
            // 
            this.Full_output_team_box.AutoSize = true;
            this.Full_output_team_box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_team_box.Controls.Add(this.Full_output_team_archetypes);
            this.Full_output_team_box.Controls.Add(this.Full_output_team_datacards_box);
            this.Full_output_team_box.Controls.Add(this.Full_output_team_datacards_header);
            this.Full_output_team_box.Controls.Add(this.Full_output_team_equipment_box);
            this.Full_output_team_box.Controls.Add(this.Full_output_team_equipment_header);
            this.Full_output_team_box.Controls.Add(this.Full_output_team_stratagem_box);
            this.Full_output_team_box.Controls.Add(this.Full_output_team_stratagem_header);
            this.Full_output_team_box.Controls.Add(this.Full_output_team_rules_box);
            this.Full_output_team_box.Controls.Add(this.Full_output_team_rules_header);
            this.Full_output_team_box.Controls.Add(this.Full_output_team_name);
            this.Full_output_team_box.Controls.Add(this.Full_output_team_ID);
            this.Full_output_team_box.Controls.Add(this.Full_output_team_name_label);
            this.Full_output_team_box.Location = new System.Drawing.Point(772, 12);
            this.Full_output_team_box.Name = "Full_output_team_box";
            this.Full_output_team_box.Size = new System.Drawing.Size(300, 458);
            this.Full_output_team_box.TabIndex = 23;
            this.Full_output_team_box.TabStop = false;
            this.Full_output_team_box.Text = "Full view";
            // 
            // Full_output_team_name
            // 
            this.Full_output_team_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_team_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_team_name.Location = new System.Drawing.Point(6, 73);
            this.Full_output_team_name.Name = "Full_output_team_name";
            this.Full_output_team_name.Size = new System.Drawing.Size(288, 18);
            this.Full_output_team_name.TabIndex = 13;
            this.Full_output_team_name.Text = "Name: ";
            this.Full_output_team_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_team_ID
            // 
            this.Full_output_team_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_team_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_team_ID.Location = new System.Drawing.Point(6, 48);
            this.Full_output_team_ID.Name = "Full_output_team_ID";
            this.Full_output_team_ID.Size = new System.Drawing.Size(288, 18);
            this.Full_output_team_ID.TabIndex = 10;
            this.Full_output_team_ID.Text = "ID: ";
            this.Full_output_team_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_team_name_label
            // 
            this.Full_output_team_name_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Full_output_team_name_label.Location = new System.Drawing.Point(6, 16);
            this.Full_output_team_name_label.Name = "Full_output_team_name_label";
            this.Full_output_team_name_label.Size = new System.Drawing.Size(288, 18);
            this.Full_output_team_name_label.TabIndex = 9;
            this.Full_output_team_name_label.Text = "Team info";
            this.Full_output_team_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Full_output_team_rules_header
            // 
            this.Full_output_team_rules_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_team_rules_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_team_rules_header.Location = new System.Drawing.Point(6, 98);
            this.Full_output_team_rules_header.Name = "Full_output_team_rules_header";
            this.Full_output_team_rules_header.Size = new System.Drawing.Size(288, 18);
            this.Full_output_team_rules_header.TabIndex = 14;
            this.Full_output_team_rules_header.Text = "Faction rules: ";
            this.Full_output_team_rules_header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_team_rules_box
            // 
            this.Full_output_team_rules_box.FormattingEnabled = true;
            this.Full_output_team_rules_box.Location = new System.Drawing.Point(6, 117);
            this.Full_output_team_rules_box.Name = "Full_output_team_rules_box";
            this.Full_output_team_rules_box.Size = new System.Drawing.Size(288, 56);
            this.Full_output_team_rules_box.TabIndex = 23;
            this.Full_output_team_rules_box.SelectedIndexChanged += new System.EventHandler(this.Full_output_team_rules_box_SelectedIndexChanged);
            // 
            // Full_output_team_stratagem_box
            // 
            this.Full_output_team_stratagem_box.FormattingEnabled = true;
            this.Full_output_team_stratagem_box.Location = new System.Drawing.Point(6, 197);
            this.Full_output_team_stratagem_box.Name = "Full_output_team_stratagem_box";
            this.Full_output_team_stratagem_box.Size = new System.Drawing.Size(288, 56);
            this.Full_output_team_stratagem_box.TabIndex = 25;
            this.Full_output_team_stratagem_box.SelectedIndexChanged += new System.EventHandler(this.Full_output_team_stratagem_box_SelectedIndexChanged);
            // 
            // Full_output_team_stratagem_header
            // 
            this.Full_output_team_stratagem_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_team_stratagem_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_team_stratagem_header.Location = new System.Drawing.Point(6, 176);
            this.Full_output_team_stratagem_header.Name = "Full_output_team_stratagem_header";
            this.Full_output_team_stratagem_header.Size = new System.Drawing.Size(288, 18);
            this.Full_output_team_stratagem_header.TabIndex = 24;
            this.Full_output_team_stratagem_header.Text = "Ploys: ";
            this.Full_output_team_stratagem_header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_team_equipment_box
            // 
            this.Full_output_team_equipment_box.FormattingEnabled = true;
            this.Full_output_team_equipment_box.Location = new System.Drawing.Point(6, 281);
            this.Full_output_team_equipment_box.Name = "Full_output_team_equipment_box";
            this.Full_output_team_equipment_box.Size = new System.Drawing.Size(288, 56);
            this.Full_output_team_equipment_box.TabIndex = 27;
            this.Full_output_team_equipment_box.SelectedIndexChanged += new System.EventHandler(this.Full_output_team_equipment_box_SelectedIndexChanged);
            // 
            // Full_output_team_equipment_header
            // 
            this.Full_output_team_equipment_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_team_equipment_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_team_equipment_header.Location = new System.Drawing.Point(6, 260);
            this.Full_output_team_equipment_header.Name = "Full_output_team_equipment_header";
            this.Full_output_team_equipment_header.Size = new System.Drawing.Size(288, 18);
            this.Full_output_team_equipment_header.TabIndex = 26;
            this.Full_output_team_equipment_header.Text = "Faction equipment: ";
            this.Full_output_team_equipment_header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_team_datacards_box
            // 
            this.Full_output_team_datacards_box.FormattingEnabled = true;
            this.Full_output_team_datacards_box.Location = new System.Drawing.Point(6, 365);
            this.Full_output_team_datacards_box.Name = "Full_output_team_datacards_box";
            this.Full_output_team_datacards_box.Size = new System.Drawing.Size(288, 56);
            this.Full_output_team_datacards_box.TabIndex = 29;
            // 
            // Full_output_team_datacards_header
            // 
            this.Full_output_team_datacards_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_team_datacards_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_team_datacards_header.Location = new System.Drawing.Point(6, 344);
            this.Full_output_team_datacards_header.Name = "Full_output_team_datacards_header";
            this.Full_output_team_datacards_header.Size = new System.Drawing.Size(288, 18);
            this.Full_output_team_datacards_header.TabIndex = 28;
            this.Full_output_team_datacards_header.Text = "Datacards: ";
            this.Full_output_team_datacards_header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Full_output_team_archetypes
            // 
            this.Full_output_team_archetypes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Full_output_team_archetypes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Full_output_team_archetypes.Location = new System.Drawing.Point(6, 424);
            this.Full_output_team_archetypes.Name = "Full_output_team_archetypes";
            this.Full_output_team_archetypes.Size = new System.Drawing.Size(288, 18);
            this.Full_output_team_archetypes.TabIndex = 30;
            this.Full_output_team_archetypes.Text = "Archetypes: ";
            this.Full_output_team_archetypes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.Full_output_team_box);
            this.Controls.Add(this.Full_output_operative_box);
            this.Controls.Add(this.Rule_description_header);
            this.Controls.Add(this.Rule_description);
            this.Controls.Add(this.Full_output_weapon_box);
            this.Controls.Add(this.teams_table_header);
            this.Controls.Add(this.ops_table_header);
            this.Controls.Add(this.weapons_table_header);
            this.Controls.Add(this.listBox_Weapons);
            this.Controls.Add(this.listBox_Operatives);
            this.Controls.Add(this.listBox_Teams);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Full_output_weapon_box.ResumeLayout(false);
            this.Full_output_operative_box.ResumeLayout(false);
            this.Full_output_team_box.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Teams;
        private System.Windows.Forms.ListBox listBox_Operatives;
        private System.Windows.Forms.Label weapons_table_header;
        private System.Windows.Forms.ListBox listBox_Weapons;
        private System.Windows.Forms.Label ops_table_header;
        private System.Windows.Forms.Label teams_table_header;
        private System.Windows.Forms.GroupBox Full_output_weapon_box;
        private System.Windows.Forms.Label Full_output_weapon_name_label;
        private System.Windows.Forms.Label Full_output_weapon_ID;
        private System.Windows.Forms.Label Full_output_weapon_type;
        private System.Windows.Forms.Label Full_output_weapon_team_name;
        private System.Windows.Forms.Label Rule_description;
        private System.Windows.Forms.Label Rule_description_header;
        private System.Windows.Forms.Label Full_output_weapon_rules_header;
        private System.Windows.Forms.ListBox Full_output_weapon_rules_box;
        private System.Windows.Forms.Label Full_output_weapon_damage;
        private System.Windows.Forms.Label Full_output_weapon_hit;
        private System.Windows.Forms.Label Full_output_weapon_attack;
        private System.Windows.Forms.Label Full_output_weapon_name;
        private System.Windows.Forms.GroupBox Full_output_operative_box;
        private System.Windows.Forms.Label Full_output_operative_name;
        private System.Windows.Forms.Label Full_output_operative_team_name;
        private System.Windows.Forms.Label Full_output_operative_ID;
        private System.Windows.Forms.Label Full_output_operative_name_label;
        private System.Windows.Forms.Label Full_output_operative_move;
        private System.Windows.Forms.Label Full_output_operative_apl;
        private System.Windows.Forms.Label Full_output_operative_wounds;
        private System.Windows.Forms.Label Full_output_operative_save;
        private System.Windows.Forms.Label Full_output_operative_keywords;
        private System.Windows.Forms.ListBox Full_output_operative_abilities_box;
        private System.Windows.Forms.Label Full_output_operative_abilities_header;
        private System.Windows.Forms.ListBox Full_output_operative_weapons_box;
        private System.Windows.Forms.Label Full_output_operative_weapons_header;
        private System.Windows.Forms.GroupBox Full_output_team_box;
        private System.Windows.Forms.Label Full_output_team_name;
        private System.Windows.Forms.Label Full_output_team_ID;
        private System.Windows.Forms.Label Full_output_team_name_label;
        private System.Windows.Forms.Label Full_output_team_archetypes;
        private System.Windows.Forms.ListBox Full_output_team_datacards_box;
        private System.Windows.Forms.Label Full_output_team_datacards_header;
        private System.Windows.Forms.ListBox Full_output_team_equipment_box;
        private System.Windows.Forms.Label Full_output_team_equipment_header;
        private System.Windows.Forms.ListBox Full_output_team_stratagem_box;
        private System.Windows.Forms.Label Full_output_team_stratagem_header;
        private System.Windows.Forms.ListBox Full_output_team_rules_box;
        private System.Windows.Forms.Label Full_output_team_rules_header;
    }
}

