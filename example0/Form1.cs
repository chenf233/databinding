using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace example0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private BindingSource _bs = new BindingSource();

        private void Form1_Load(object sender, EventArgs e)
        {
            // 1. 通过 Designer 绑定
            airplaneBindingSource.Add(new Airplane("Boeing 747", 800));
            airplaneBindingSource.Add(new Airplane("Airbus A380", 1023));
            airplaneBindingSource.Add(new Airplane("Cessna 162", 67));

             _bs.AddingNew += (s, v) => Debug.WriteLine(@"AddingNew");
            _bs.BindingComplete += (s, v) => Debug.WriteLine(@"BindingComplete");
            _bs.CurrentChanged += (s, v) => Debug.WriteLine(@"CurrentChanged");
            _bs.CurrentItemChanged += (s, v) => Debug.WriteLine(@"CurrentItemChanged");
            _bs.DataError += (s, v) => Debug.WriteLine(@"DataError");
            _bs.DataMemberChanged += (s, v) => Debug.WriteLine(@"DataMemberChanged");
            _bs.DataSourceChanged += (s, v) => Debug.WriteLine(@"DataSourceChanged");
            _bs.ListChanged += (s, v) => Debug.WriteLine(@"ListChanged");
            _bs.PositionChanged += (s, v) => Debug.WriteLine(@"PositionChanged");

            // 2. 通过代码绑定
            _bs.DataSource = typeof(Airplane);
            var a = new Airplane("Boeing 747", 800);
            a.Passengers = new List<Passenger>();
            a.Passengers.Add(new Passenger("张三"));
            a.Passengers.Add(new Passenger("李四"));
            _bs.Add(a);
            a = new Airplane("Airbus A380", 1023);
            a.Passengers = new List<Passenger>();
            a.Passengers.Add(new Passenger("赵四"));
            a.Passengers.Add(new Passenger("刘能"));
            a.Passengers.Add(new Passenger("谢广坤"));
            _bs.Add(a);
            a = new Airplane("Cessna 162", 67);
            a.Passengers = new List<Passenger>();
            a.Passengers.Add(new Passenger("维多利亚"));
            a.Passengers.Add(new Passenger("伊丽莎白"));
            a.Passengers.Add(new Passenger("康斯坦丁"));
            _bs.Add(a);
            dataGridView2.DataSource = _bs;
            textBox2.DataBindings.Add("Text", _bs, "Model");
            
            // 属性嵌套展示
            comboBox1.DataSource = _bs;
            comboBox1.DisplayMember = "Passengers.Name";

            // 3. 设定 DataMember
            var _bs2 = new BindingSource();  // local 对象貌似也能正常工作
            var airplane = new Airplane("Boeing 747", 800);
            airplane.Passengers = new List<Passenger>();
            airplane.Passengers.Add(new Passenger("Johnny"));
            airplane.Passengers.Add(new Passenger("Wood"));
            _bs2.DataSource = airplane;
            _bs2.DataMember = "Passengers";
            dataGridView3.DataSource = _bs2;

            textBox3.DataBindings.Add("Text", _bs2, "Name");
        }
    }
}
