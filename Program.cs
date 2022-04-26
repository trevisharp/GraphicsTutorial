using System.Windows.Forms;
using System.Drawing;

Application.SetHighDpiMode(HighDpiMode.SystemAware);
Application.EnableVisualStyles();
Application.SetCompatibleTextRenderingDefault(false);

var form = new Form();

form.WindowState = FormWindowState.Maximized;
form.FormBorderStyle = FormBorderStyle.None;
form.KeyPreview = true;

PictureBox pb = new PictureBox();
pb.Dock = DockStyle.Fill;
form.Controls.Add(pb);

Bitmap bmp = null;
Graphics g = null;
Timer tm = new Timer();
tm.Interval = 25;

Image img = new Bitmap("FOUk4ieXEAQ1vk5.jpg");
int x = 20;
int y = 20;
int dg = 1;
int dx = 5;
int dy = 0;

form.Load += delegate
{
    bmp = new Bitmap(pb.Width, pb.Height);
    g = Graphics.FromImage(bmp);
    tm.Start();
};

form.KeyDown += (s, e) =>
{
    switch (e.KeyCode)
    {
        case Keys.Escape:
            Application.Exit();
            break;
        case Keys.Left:
            dx--;
            break;
        case Keys.Right:
            dx++;
            break;
    }
};

tm.Tick += delegate
{
    g.Clear(Color.White);

    Pen pen = new Pen(Color.Aqua, 4f);

    g.DrawImage(img, new Rectangle(x, y, 200, 200), new Rectangle(x, y, 200, 200), GraphicsUnit.Pixel);
    g.DrawRectangle(pen, x, y, 200, 200);

    x += dx;
    dy += dg;
    y += dy;

    if (y + 200 > bmp.Height)
    {
        dy = -dy;
    }

    pb.Image = bmp;
};

Application.Run(form);