using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace LAB_3._3
{
    public partial class Form1 : Form
    {
        Man m = null, m1 = null;
        public Form1()
        {
            InitializeComponent();
        }
        static bool inputDouble(ref double x, string Pov)
        {
            string S;
            S = x.ToString();
            povtor:
            S = Interaction.InputBox(Pov,"Wotch ", S);
            try
            {
                x = Convert.ToDouble(S);
            }
            catch (System.FormatException)
            {
                if (MessageBox.Show(" sds", "chto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                goto povtor;
                else
                    return false;
            }
            return true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

       private void button1_Click(object sender, EventArgs e)
        {
            double weight, height, age;
            try
            {
                do {
                    weight = Convert.ToDouble(Interaction.InputBox("Вес в килограммах ", "Введення "));
                }
                while(weight<0) ;
                do {
                    height = Convert.ToDouble(Interaction.InputBox("Pост в сантиметрах ", "Введення "));
                }
                while (height<0);
                do {
                    age = Convert.ToDouble(Interaction.InputBox("Bозраст в годах ", "Введення"));
                }
                while (age<0);
                Man prodykt1 = new Man(weight, height, age);
                prodykt1.Info();
            }
            catch (FormatException error)
            {
                MessageBox.Show("введите цифры ", error.Message);
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            double weight, height, age;
            try
            {
                do 
                {
                        weight = Convert.ToDouble(Interaction.InputBox("Вес в килограммах ", "Введення "));
                }
                while (weight <= 0);
                do {
                    height = Convert.ToDouble(Interaction.InputBox("Pост в сантиметрах ", "Введення "));
                }
                while (height<=0);
                do {
                    age = Convert.ToDouble(Interaction.InputBox("Bозраст в годах ", "Введення"));
                }
                while (age<=0);
                Feman prodykt = new Feman(weight, height, age);
                prodykt.Info();
            }
            catch (FormatException error)
            {
                MessageBox.Show("введите цифры", error.Message);
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Man prodykt = new Man(0, 0, 0);

            prodykt.Info();
            
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            Feman prodykt = new Feman(0,0,0);
            prodykt.Info();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var m = new Man(34,0,0);
            m.Info();
            var m1 = new Man(34,0,0);
            m1.Info();
            if (m == m1)
                MessageBox.Show("Они равные");
            else
                MessageBox.Show("Они не есть равными");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double weight=7, height=5, age=4;
            if (!inputDouble(ref weight, " Вес"))
                return;
            if (!inputDouble(ref height, "poct"))
                return;
            if (!inputDouble(ref age, "Bo3pact"))
                return;
            MessageBox.Show("KAl Stvoreno");
            m = new Man(weight,height,age);
        }
    }
}

/// <summary>
// get set -это модификаторы доступа к свойству.,,,,
// get-это как доступ только для чтения, считывает поле свойства.,,,,
// set-это как доступ только для записи, задает значение свойства.,,,
// value-Параметр value представляет передаваемое значение,,,
// Они обеспечивают простой доступ к полям классов и структур, узнать их значение или выполнить их установку
// Стандартное определение свойства содержит блоки get и set. 
// В блоке get мы возвращаем значение поля, а в блоке set устанавливаем.
// Параметр value представляет передаваемое значение.
//Если бы переменная age была бы публичной, то мы могли бы передать ей извне любое значение, в том числе отрицательное. Свойство же позволяет скрыть данные объекты и опосредовать к ним доступ.
/// <summary>

abstract class kalori
{
    private double weight { get; set; } // вес

    private double height { get; set; }  // рост

    private double age { get; set; } // возраст

    public abstract void Info(); //абстрактными методами наследуется интерфейс, представленный этими абстрактными методами.
  
}


class Man : kalori // калоррии для мужщин
{
    private double weight, height, age;
    public double minSide()
    {
        return Math.Min(Math.Min(Height, Weight), Age);
    }
    public double maxSide()
    {
        double max = Height;
        if (Weight > max) max = Weight;
        if (Age > max) max = Age;
        return max;
    }
    public double man()
    {
        return (Weight + Height + Age);
    }


    public static bool operator ==(Man m, Man m1)
    {
        return m.minSide() == m1.minSide() &&
       m.maxSide() == m1.maxSide() &&
       m.man() == m1.man();
    }
    public static bool operator !=(Man m, Man m1)
    {
        return !(m == m1);
    }

    public double Weight
    {

        get { return weight; }

        set
        {
            
            if (value < 0)
            {
                MessageBox.Show("не может быть отрицательным 0");
                return;
            }
            weight = value;
        }
    }

    public double Height
    {

        get { return height; }

        set
        {
            if (value < 0)
            {
                MessageBox.Show("не может быть отрицательным 1");
                return;
            }
            height = value;
        }
    }
    public double Age
    {

        get { return age; }

        set
        {
            if (value < 0)
            {
                MessageBox.Show("не может быть отрицательным 2 ");
                return;
            }
           age = value;
        }
    }

    public Man(double weight, double height, double age )  // конструктор
    {
        Weight = weight;
        Height = height;
        Age = age;
    }
    
    public double lol()
    {
        return (10 * weight) + (6.25 * height) - (5 * age) +5;
    }
    public override void  Info()
    {
        MessageBox.Show("Bес в килограммах: " + weight.ToString() + " Pост в сантиметрах: " + height.ToString() + " Bозраст:    " + age.ToString() + "Kоличество калорий в день для Мужщин: " + lol().ToString(), " tyk-tyk", MessageBoxButtons.OK, MessageBoxIcon.Information);
        do
        {
            
            if (lol() <= 0)
            {
                MessageBox.Show("Введите коректные данне, число не может быть Отрицательным" + lol().ToString(), " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        while (lol()<=0);
    }
   
}

class Feman : kalori
{

    private double weight, height, age;
   
      public double Weight
      {
        
        get { return weight; }
        
        set
        {
                if (value < 0)// валюе записывает то что мы ввели  и переверяет подходит ли оно мнам
                {
                    MessageBox.Show("не может быть отрицательным");
                    return;
                }
                weight = value;
        }
      }


    public double Height
    {
        get { return height; }
        set
        {
            if (value < 0)
            {
                MessageBox.Show(" не сохраненно");
                return;
            }
            height = value;
        }
    }
    public double Age
    {
            get { return age; }
            set {
                if (value < 0)
                {
                MessageBox.Show("возраст не может быть отрицательным");
                return;
                }
                age = value;
            }
        
    }

    public Feman(double weight, double height, double age) // конструктор
    {
        Weight = weight;
        Height = height;
        Age = age;
    }
    public double lo()
    {
        return  (10 * weight) + (6.25 * height) - (5 * age) - 161;
       
    }
    public override void Info()
    {
        
            MessageBox.Show("Kоличество калорий в день для Женщин: " + lo().ToString(), " tyk-tyk", MessageBoxButtons.OK, MessageBoxIcon.Information);

    }
}
