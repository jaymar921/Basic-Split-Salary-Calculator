
// get the inputs
using System.Globalization;
using System.Text;

Console.Write("Enter Taxable Salary: ");
_ = double.TryParse(Console.ReadLine() ?? "0", out double salary_base);
Console.Write("Enter Non Taxable Split: ");
_ = double.TryParse(Console.ReadLine() ?? "0", out double salary_split);
Console.Write("Enter Tax %: ");
_ = double.TryParse(Console.ReadLine() ?? "0", out double tax_percent);

calculateSplit(salary_base, salary_split, tax_percent);

static void calculateSplit(double salary, double split, double tax_percent)
{
    CultureInfo peso = CultureInfo.GetCultureInfo("fil-PH");

    double salary_net = salary - (salary * (tax_percent / 100));
    double split_salary_net = salary - split;
    split_salary_net = split_salary_net - (split_salary_net * (tax_percent / 100));

    double taxed_year = (salary_net * 12) + salary;
    double split_year = ((split_salary_net + split) * 12) + salary - split;

    double difference = (split_year - taxed_year);
    double difference_in_percent = (difference / taxed_year) * 100;



    Console.OutputEncoding = Encoding.Unicode;

    Console.WriteLine("\n\n=================================================\n");
    Console.WriteLine($"SALARY {salary.ToString("C",peso)}");
    Console.WriteLine("\n===================[NO SPLIT]====================");
    Console.WriteLine($"MONTHLY: {salary_net.ToString("C", peso)}/MO");
    Console.WriteLine($"BI-MONTHLY: {(salary_net/2).ToString("C", peso)}");
    Console.WriteLine($"YEARLY: {(salary_net * 12).ToString("C", peso)}");
    Console.WriteLine($"13TH MONTH PAY: {(salary).ToString("C", peso)}");
    Console.WriteLine($"YEARLY + 13TH MONTH: {((salary_net * 12) + salary).ToString("C", peso)}");
    Console.WriteLine($"TAX: {((salary * (tax_percent / 100)) * 12).ToString("C",peso)}/YR");
    Console.WriteLine("\n=====================[SPLIT]=====================");
    Console.WriteLine($"TAXABLE: {(salary - split).ToString("C",peso)}  |  NON-TAXABLE: {split.ToString("C", peso)}");
    Console.WriteLine($"MONTHLY: {(split_salary_net + split).ToString("C", peso)}/MO");
    Console.WriteLine($"BI-MONTHLY: {((split_salary_net + split) / 2).ToString("C", peso)}");
    Console.WriteLine($"YEARLY: {((split_salary_net + split) * 12).ToString("C", peso)}");
    Console.WriteLine($"13TH MONTH PAY: {(salary - split).ToString("C", peso)}");
    Console.WriteLine($"YEARLY + 13TH MONTH: {(((split_salary_net + split) * 12) + salary - split).ToString("C", peso)}");
    Console.WriteLine($"TAX: {(((salary - split) * (tax_percent / 100)) * 12).ToString("C", peso)}/YR");

    Console.WriteLine($"\n\nDIFFERENCE: {difference.ToString("C",peso)} ({difference_in_percent.ToString("0.##")}%) OR {(difference/12).ToString("C", peso)}/MO\n\n\n\n");
}
