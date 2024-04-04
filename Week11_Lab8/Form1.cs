using static System.Windows.Forms.LinkLabel;

namespace Week11_Lab8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                int num = int.Parse(textBox1.Text);

                long a = 0;
                long b = 1;
                long c = 0;

                if (num <= 0)
                {
                    throw new Exception("Enter positive integer.");
                }

                listBox1.Items.Add(0);

                for (int i = 1; i < num; i++)
                {
                    long v = await Task.Run(() =>
                                        {
                                            c = a + b;
                                            a = b;
                                            b = c;
                                            Thread.Sleep(1000);
                                            return a;
                                        });
                    listBox1.Invoke(new Action(async () =>
                    {
                        listBox1.Items.Add(v);
                    }));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

        

                