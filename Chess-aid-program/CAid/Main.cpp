#include <iostream>
#include <fstream>
#include <string>
using namespace std;

int main() {
	ofstream fout("sah.txt");
	for (int i = 0; i < 8; i++) {
		for (int j = 0; j < 8; j++) {
			fout << "this._" << 8 - j << char(int('A') + i) << " = new System.Windows.Forms.PictureBox();\n";
		}
	}
	fout << "\n\n----------------------------------------------------------------\n\n";
	for (int i = 0; i < 8; i++) {
		for (int j = 0; j < 8; j++) {
			fout << "((System.ComponentModel.ISupportInitialize)(this._" << 8 - j << char(int('A') + i) << ")).BeginInit();\n";
		}
	}
	fout << "\n\n----------------------------------------------------------------\n\n";
	for (int i = 0; i < 8; i++) {
		for (int j = 0; j < 8; j++) {
			fout << "this.panel2.Controls.Add(this._" << 8 - j << char(int('A') + i) << ");\n";
		}
	}
	fout << "\n\n----------------------------------------------------------------\n\n";
	for (int i = 0; i < 8; i++) {
		for (int j = 0; j < 8; j++) {
			fout << "\/\/\n\/\/ _" << j + 1 << char(int('H') - i) << "\n";
			fout << "\/\/\n";
			fout << "this._" << j + 1 << char(int('H') - i) << ".Location = new System.Drawing.Point(" << j * 64 << ", " << i * 64 << ");\n";
			fout << "this._" << j + 1 << char(int('H') - i) << ".Name = \"_" << 8 - j << char(int('H') - i) << "\"\;\n";
			fout << "this._" << j + 1 << char(int('H') - i) << ".Size = new System.Drawing.Size(64, 64);\n";
			fout << "this._" << j + 1 << char(int('H') - i) << ".TabIndex = 0;\n";
			fout << "this._" << j + 1 << char(int('H') - i) << ".TabStop = false;\n";
		}
	}
	fout << "\n\n----------------------------------------------------------------\n\n";
	for (int i = 0; i < 8; i++) {
		for (int j = 0; j < 8; j++) {
			if (i % 2 == 0 && j % 2 == 0) {
				fout << "this._" << j + 1 << char(int('A') + i) << ".BackColor = Color.FromArgb(132, 107, 86);\n";
			}
			if (i % 2 == 1 && j % 2 == 1) {
				fout << "this._" << j + 1 << char(int('A') + i) << ".BackColor = Color.FromArgb(132, 107, 86);\n";
			}
			if (i % 2 == 0 && j % 2 == 1) {
				fout << "this._" << j + 1 << char(int('A') + i) << ".BackColor = System.Drawing.Color.Silver;\n";
			}
			if (i % 2 == 1 && j % 2 == 0) {
				fout << "this._" << j + 1 << char(int('A') + i) << ".BackColor = System.Drawing.Color.Silver;\n";
			}
		}
	}
	fout << "\n\n----------------------------------------------------------------\n\n";
	for (int i = 0; i < 8; i++) {
		for (int j = 0; j < 8; j++) {
			fout << " private System.Windows.Forms.PictureBox _" << 8 - j << char(int('A') + i) << ";\n";
		}
	}
	fout << "\n\n----------------------------------------------------------------\n\n";
	for (int i = 0; i < 8; i++) {
		for (int j = 0; j < 8; j++) {
			fout << "pozitie[" << i + 1 << ", " << j + 1 << "] = _" << j + 1 << char(int('A') + i) << ";\n";
		}
	}
	fout << "\n\n----------------------------------------------------------------\n\n";
	for (int i = 0; i < 8; i++) {
		for (int j = 0; j < 8; j++) {
			fout << "locatii[" << i + 1 << ", " << j + 1 << "] = " << char(int('A') + i) << j + 1 << "; ";
		}
		fout << "\n";
	}
	fout << "\n\n----------------------------------------------------------------\n\n";
	//            H8.imagineLocatie.BackColor = Color.FromArgb(132, 107, 86);
	int ct = 1;
	for (int i = 0; i < 8; i++) {
		for (int j = 0; j < 8; j++) {
			if (i % 2 == 0 && j % 2 == 0) {
				fout << char(int('A') + i) << j + 1 << ".imagineLocatie.BackColor = Color.FromArgb(132, 107, 86); ";
				ct++;
			}
			if (i % 2 == 1 && j % 2 == 1) {
				fout << char(int('A') + i) << j + 1 << ".imagineLocatie.BackColor = Color.FromArgb(132, 107, 86); ";
				ct++;
			}
			if (i % 2 == 0 && j % 2 == 1) {
				fout << char(int('A') + i) << j + 1 << ".imagineLocatie.BackColor = System.Drawing.Color.Silver; ";
				ct++;
			}
			if (i % 2 == 1 && j % 2 == 0) {
				fout << char(int('A') + i) << j + 1 << ".imagineLocatie.BackColor = System.Drawing.Color.Silver; ";
				ct++;
			}
			if (ct == 3) { fout << "\n"; ct = 1; }
		}
		fout << "\n";
	}
	
	fout << "\n\n----------------------------------------------------------------\n\n";	
	for (int i = 0; i < 8; i++) {
		for (int j = 0; j < 8; j++) {
			fout << "private void _" << j + 1 << char(int('A') + i) << "_Click(object sender, EventArgs e)\n{\n";
			fout << "if (clickCounter == 1 && "<< char(int('A') + i) << j + 1 <<" == orig)\n{\nRearanjare(locatii); clickCounter=100; RestoreCulori(locatii);}";
			fout << "if (clickCounter == 0 && _" << j + 1 << char(int('A') + i) << ".BackgroundImage != null && randMutare==" << char(int('A') + i) << j + 1 << ".culoare)\n{\n";
			fout << char(int('A') + i) << j + 1 << ".piesa.VerificaPosibilitati(" << i + 1 << ", " << j + 1 << ", locatii);\n";
			fout << "if (" << char(int('A') + i) << j + 1 << ".poateFaceMiscari == true)\n{\norig = " << char(int('A') + i) << j + 1 << ";\nclickCounter++;\n}\n}\n";
			fout << "if (clickCounter==100) clickCounter=0;";
			fout << "if (clickCounter == 1 && " << char(int('A') + i) << j + 1 << " != orig && " << char(int('A') + i) << j + 1 << ".sePoate == true)\n{\n" << char(int('A') + i) << j + 1 << ".Muta(orig, listaMiscari); ";
			fout << "orig.StergeLocatie(); RandNou(locatii);\nclickCounter=0; RestoreCulori(locatii);\n}\n}\n\n";
		}
	}
	fout << "\n\n----------------------------------------------------------------\n\n";
	for (int i = 0; i < 8; i++) {
		for (int j = 0; j < 8; j++) {
			fout << "this._" << j + 1 << char(int('A') + i) << ".Click += new System.EventHandler(this._" << j + 1 << char(int('A') + i) << "_Click);\n";
		}
	}
	fout << "\n\n----------------------------------------------------------------\n\n";
	for (int i = 0; i < 8; i++) {
		for (int j = 0; j < 8; j++) {
			fout << char(int('A') + i) << j + 1 << ".nume=\"" << char(int('A') + i) << j + 1 << "\"; ";
		}
		fout << "\n";
	}
	fout << "\n\n----------------------------------------------------------------\n\n";
	for (int i = 0; i < 8; i++) {
		for (int j = 0; j < 8; j++) {
			fout << "Boxes[_" << j + 1 << char(int('A') + i) << "] = " << char(int('A') + i) << j + 1 << "; ";
		}
		fout << "\n";
	}
}