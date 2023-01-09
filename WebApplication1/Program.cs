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
        sr.WriteLine("a - " + a + ", b - " + b + ", x - " + x + " Лежит на отрезке");
        sr.Close();
        return "Лежит на отрезке";
    }

    sr.WriteLine("a - " + a + ", b - " + b + ", x - " + x + " Не лежит на отрезке");
    sr.Close();
    return "Не лежит на отрезке";
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
        sr.WriteLine("x - " + x + ", y - " + y + ", z - " + z + " answer - Не существует");
        sr.Close ();
        return "Не сущетвует";
    }
    if (Math.Pow(iX, 2) + Math.Pow(iY, 2) == Math.Pow(iZ, 2) || Math.Pow(iX, 2) + Math.Pow(iZ, 2) == Math.Pow(iY, 2) || Math.Pow(iY, 2) + Math.Pow(iZ, 2) == Math.Pow(iX, 2))
    {
        sr.WriteLine("x - " + x + ", y - " + y + ", z - " + z + " answer - Cуществует и прямоугольный");
        sr.Close();
        return "Cуществует и прямоугольный";
    }
    sr.WriteLine("x - " + x + ", y - " + y + ", z - " + z + " answer - Cуществует и не прямоугольный");
    sr.Close();
    return "Cуществует и не прямоугольный";
}