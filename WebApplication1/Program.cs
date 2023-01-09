using System.IO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync("html/index.html");
});

app.MapGet("/otrez/{a}/{b}/{x}", OtrezRequest);
app.MapGet("/know/{x}/{y}/{z}", KnowRequest);
app.Run();


string OtrezRequest(string a, string b, string x)
{
    StreamWriter sr = new StreamWriter("./log.txt", true);
    if(double.Parse(a) <= double.Parse(x) && double.Parse(b) >= double.Parse(x))
    {
        sr.WriteLine("a - " + a + ", b - " + b + ", x - " + x + " ����� �� �������");
        sr.Close();
        return "����� �� �������";
    }

    sr.WriteLine("a - " + a + ", b - " + b + ", x - " + x + " �� ����� �� �������");
    sr.Close();
    return "�� ����� �� �������";
}

string KnowRequest(string x, string y, string z)
{
    StreamWriter sr = new StreamWriter("./log.txt", true);

    bool flag1 = false;
    double iZ = double.Parse(z);
    double iY = double.Parse(y);
    double iX = double.Parse(x);
    if(iX + iY > iZ && iX + iZ > iY && iY + iZ > iX) flag1 = true;
    if (!flag1)
    {
        sr.WriteLine("x - " + x + ", y - " + y + ", z - " + z + " answer - �� ����������");
        sr.Close ();
        return "�� ���������";
    }
    if (Math.Pow(iX, 2) + Math.Pow(iY, 2) == Math.Pow(iZ, 2) || Math.Pow(iX, 2) + Math.Pow(iZ, 2) == Math.Pow(iY, 2) || Math.Pow(iY, 2) + Math.Pow(iZ, 2) == Math.Pow(iX, 2))
    {
        sr.WriteLine("x - " + x + ", y - " + y + ", z - " + z + " answer - C��������� � �������������");
        sr.Close();
        return "C��������� � �������������";
    }
    sr.WriteLine("x - " + x + ", y - " + y + ", z - " + z + " answer - C��������� � �� �������������");
    sr.Close();
    return "C��������� � �� �������������";
}