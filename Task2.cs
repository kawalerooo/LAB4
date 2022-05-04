namespace Uniwersytet
{
    class Student {
        public int nr_indeksu { get; private set;}
        private string imie {get; set;}
        private string nazwisko {get; set;}
        private int rok_st {get; set;}
        public List<float> Oceny = new List<float>();

        public Student(int nr_indeksu, string imie, string nazwisko, int rok_st) {
            this.nr_indeksu = nr_indeksu;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.rok_st = rok_st;
        }

        public float sredniaOcen() {
            return Oceny.Count > 0 ? Oceny.Sum() / Oceny.Count : 0;
        }

        public override string? ToString() {
            return String.Format("({0}) {1} {2}", nr_indeksu, imie, nazwisko);
        }
    }

    class Uni {
        public float[] ListaDopuszczalnychOcen;
        public List<Student> ListaStudentow = new List<Student>();

        public Uni() {
            ListaDopuszczalnychOcen = new float[7] {2.0F, 2.5F, 3.0F, 3.5F, 4.0F, 4.5F, 5.0F};
        }

        public void dodajStudenta(Student student) {
            ListaStudentow.Add(student);
            Console.Write(String.Format("Podaj oceny dla {0}: ", student));
            string[] wyrazy = (Console.ReadLine() ?? " ").Split(" ");
            foreach(string wyraz in wyrazy) {
                try {
                    float wczytanaOcena = float.Parse(wyraz);
                    if(!ListaDopuszczalnychOcen.Any(ocena => ocena == wczytanaOcena)) {
                        throw new FormatException();
                    }
                    student.Oceny.Add(wczytanaOcena);
                } catch(FormatException) {
                    Console.WriteLine(string.Format("Niepoprawna ocena: {0}", wyraz));
                }
            }
        }

        public void usunStudenta(int nr_indeksu) {
            ListaStudentow.RemoveAll(student => student.nr_indeksu == nr_indeksu);
        }

        public void obliczSrednia(int nr_indeksu) {
            Student? student = ListaStudentow.Find(student => student.nr_indeksu == nr_indeksu);
            if(student == null) {
                Console.WriteLine("Nie znaleziono studenta o podanym numerze indeksu");
            } else {
                obliczSrednia(student);
            }
        }

        public void obliczSrednia(Student student) {
            Console.WriteLine(String.Format("Srednia {0}: {1:0.00}", student, student.sredniaOcen()));
        }

        public void obliczSredniaAll() {
            foreach(Student student in ListaStudentow) {
                obliczSrednia(student);
            }
        }
    }
    class Hello {         
        static void Main(string[] args) {
            Student s1 = new Student(123, "Jan", "Nowak", 2021);
            Student s2 = new Student(124, "Jan", "Kowalski", 2022);
            Student s3 = new Student(125, "Anna", "Nowak", 2022);
            Uni uni = new Uni();
            uni.dodajStudenta(s1);
            uni.dodajStudenta(s2);
            uni.dodajStudenta(s3);
            uni.obliczSrednia(124);
            uni.usunStudenta(124);
            uni.obliczSrednia(124);
            uni.obliczSredniaAll();
        }
    }
}
