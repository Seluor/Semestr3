using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MinimizationApp
{
    public partial class Form1 : Form
    {
        private Chart chart1;

        public Form1()
        {
            InitializeComponent();
            InitializeChart();
        }

        private void InitializeChart()
        {

            chart1 = new Chart();
            chart1.Size = new System.Drawing.Size(600, 400);
            chart1.Location = new System.Drawing.Point(205, 255);


            ChartArea chartArea = new ChartArea("ChartArea1");
            chart1.ChartAreas.Add(chartArea);


            Series series = new Series();
            series.ChartArea = "ChartArea1";
            series.Name = "Function";
            series.ChartType = SeriesChartType.Line;


            for (double x = -10; x <= 10; x += 0.1)
            {
                double y = CalculateFunction(x);
                series.Points.AddXY(x, y);
            }


            chart1.Series.Add(series);


            chartArea.AxisX.Title = "X-ось";
            chartArea.AxisY.Title = "Y-ось";
            chartArea.AxisX.Minimum = -10;
            chartArea.AxisX.Maximum = 10;
            chartArea.AxisY.Minimum = -10;
            chartArea.AxisY.Maximum = 10;


            this.Controls.Add(chart1); 
        }


        private double CalculateFunction(double x)
        {

            return (27 - 18 * x + 2 * Math.Pow(x, 2)) * Math.Pow(Math.E, -(x / 3));
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {

            double a, b, epsilon;

            if (!double.TryParse(aTextBox.Text, out a) || !double.TryParse(bTextBox.Text, out b) || !double.TryParse(epsilonTextBox.Text, out epsilon))
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения для a, b и точности (epsilon).", "Ошибка");
                return;
            }

            double minimum = CalculateMinimum(a, b, epsilon);
            solutionTextBox.Text = $"Минимум функции: {minimum:F6}";
        }

        private double CalculateMinimum(double a, double b, double epsilon)
        {
            double x1 = a;
            double x2 = b;

            do
            {
                double x3 = (x1 + x2) / 2;
                double f1 = CalculateFunction(x1);
                double f2 = CalculateFunction(x2);
                double f3 = CalculateFunction(x3);

                if (f1 * f3 < 0)
                {
                    x2 = x3;
                }
                else
                {
                    x1 = x3;
                }
            } while (Math.Abs(x2 - x1) > epsilon);

            return (x1 + x2) / 2;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            aTextBox.Clear();
            bTextBox.Clear();
            epsilonTextBox.Clear();
            solutionTextBox.Clear();
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.aLabel = new System.Windows.Forms.Label();
            this.aTextBox = new System.Windows.Forms.TextBox();
            this.bTextBox = new System.Windows.Forms.TextBox();
            this.epsilonTextBox = new System.Windows.Forms.TextBox();
            this.bLabel = new System.Windows.Forms.Label();
            this.epsilonLabel = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.solutionTextBox = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();

            this.aLabel.AutoSize = true;
            this.aLabel.Location = new System.Drawing.Point(52, 52);
            this.aLabel.Name = "aLabel";
            this.aLabel.Size = new System.Drawing.Size(63, 20);
            this.aLabel.TabIndex = 0;
            this.aLabel.Text = "Enter A";
            this.aLabel.Click += new System.EventHandler(this.label1_Click);

            this.aTextBox.Location = new System.Drawing.Point(56, 75);
            this.aTextBox.Name = "aTextBox";
            this.aTextBox.Size = new System.Drawing.Size(100, 26);
            this.aTextBox.TabIndex = 1;

            this.bTextBox.Location = new System.Drawing.Point(56, 142);
            this.bTextBox.Name = "bTextBox";
            this.bTextBox.Size = new System.Drawing.Size(100, 26);
            this.bTextBox.TabIndex = 2;

            this.epsilonTextBox.Location = new System.Drawing.Point(209, 75);
            this.epsilonTextBox.Name = "epsilonTextBox";
            this.epsilonTextBox.Size = new System.Drawing.Size(278, 26);
            this.epsilonTextBox.TabIndex = 3;
            this.epsilonTextBox.TextChanged += new System.EventHandler(this.epsilonTextBox_TextChanged);

            this.bLabel.AutoSize = true;
            this.bLabel.Location = new System.Drawing.Point(52, 119);
            this.bLabel.Name = "bLabel";
            this.bLabel.Size = new System.Drawing.Size(63, 20);
            this.bLabel.TabIndex = 4;
            this.bLabel.Text = "Enter B";

            this.epsilonLabel.AutoSize = true;
            this.epsilonLabel.Location = new System.Drawing.Point(205, 52);
            this.epsilonLabel.Name = "epsilonLabel";
            this.epsilonLabel.Size = new System.Drawing.Size(61, 20);
            this.epsilonLabel.TabIndex = 5;
            this.epsilonLabel.Text = "Epsilon";

            this.calculateButton.Location = new System.Drawing.Point(593, 66);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(115, 35);
            this.calculateButton.TabIndex = 6;
            this.calculateButton.Text = "Рассчитать";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click_1);

            this.clearButton.Location = new System.Drawing.Point(714, 66);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(115, 35);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click_1);

            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(205, 228);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(57, 20);
            this.resultLabel.TabIndex = 8;
            this.resultLabel.Text = "Ответ";

            this.solutionTextBox.Location = new System.Drawing.Point(290, 226);
            this.solutionTextBox.Name = "solutionTextBox";
            this.solutionTextBox.Size = new System.Drawing.Size(210, 26);
            this.solutionTextBox.TabIndex = 11;

            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(744, 226);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Функция";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(300, 300);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);

            this.ClientSize = new System.Drawing.Size(1818, 846);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.solutionTextBox);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.epsilonLabel);
            this.Controls.Add(this.bLabel);
            this.Controls.Add(this.epsilonTextBox);
            this.Controls.Add(this.bTextBox);
            this.Controls.Add(this.aTextBox);
            this.Controls.Add(this.aLabel);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label aLabel;

        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        private System.Windows.Forms.TextBox aTextBox;
        private System.Windows.Forms.TextBox bTextBox;
        private System.Windows.Forms.TextBox epsilonTextBox;
        private Label bLabel;
        private Label epsilonLabel;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Button clearButton;
        private Label resultLabel;
        private System.Windows.Forms.TextBox solutionTextBox;

        private void calculateButton_Click_1(object sender, EventArgs e)
        {
            calculateButton.Click += new EventHandler(CalculateButton_Click);

        }

        private void clearButton_Click_1(object sender, EventArgs e)
        {
            clearButton.Click += new EventHandler(ClearButton_Click);
        }

        private void epsilonTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void functionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            HitTestResult hit = chart1.HitTest(me.X, me.Y);


            if (hit.ChartElementType == ChartElementType.DataPoint)
            {
                DataPoint dataPoint = chart1.Series[0].Points[hit.PointIndex];
                double xValue = dataPoint.XValue;
                double yValue = dataPoint.YValues[0];
                MessageBox.Show($"Координаты точки: X = {xValue:F2}, Y = {yValue:F2}", "Информация о точке");
            }
        }


    }
}
