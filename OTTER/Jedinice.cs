namespace OTTER
{
    public class Legionari : Sprite
    {
        public Legionari(int jb) : base("sprites\\Legionary.jpg", 0, 0)
        {
            JedinstveniBroj = jb;
            Nsnagakonjistrijelci = 25;
            Nsnagakonji = 20;
            Nsnagalegionari = 10;
            Osnagakonjistrijelci = 5;
            Osnagakonji = 20;
            Osnagalegionari = 10;
            Ljudstvo = 1000;
            Moral = 100;
        }
    }

    public class KonjiStrijelci : Sprite
    {
        public KonjiStrijelci(int jb) : base("sprites\\HorseArcher.jpg", 0, 0)
        {
            JedinstveniBroj = jb;
            Nsnagakonjistrijelci = 10;
            Nsnagakonji = 15;
            Nsnagalegionari = 20;
            Osnagakonjistrijelci = 10;
            Osnagakonji = 5;
            Osnagalegionari = 5;
            Ljudstvo = 750;
            Moral = 80;
        }
    }

    public class Konjanici : Sprite
    {
        public Konjanici(int jb) : base("sprites\\Horseman.jpg", 0, 0)
        {
            JedinstveniBroj = jb;
            Nsnagakonjistrijelci = 20;
            Nsnagakonji = 10;
            Nsnagalegionari = 5;
            Osnagakonjistrijelci = 5;
            Osnagakonji = 10;
            Osnagalegionari = 5;
            Ljudstvo = 750;
            Moral = 80;
        }
    }

    public class Infantry : Sprite
    {
        public Infantry(int jb) : base("sprites\\Infantry.jpg", 0, 0)
        {
            JedinstveniBroj = jb;
            Nsnagakonjistrijelci = 20;
            Nsnagakonji = 15;
            Nsnagalegionari = 10;
            Osnagakonjistrijelci = 5;
            Osnagakonji = 10;
            Osnagalegionari = 10;
            Ljudstvo = 500;
            Moral = 90;
        }
    }

    public class KonjiStrijelci1 : Sprite
    {
        public KonjiStrijelci1(int jb) : base("sprites\\HorseArcher1.jpg", 0, 0)
        {
            JedinstveniBroj = jb;
            Nsnagakonjistrijelci = 10;
            Nsnagakonji = 15;
            Nsnagalegionari = 20;
            Osnagakonjistrijelci = 10;
            Osnagakonji = 5;
            Osnagalegionari = 5;
            Ljudstvo = 1000;
            Moral = 100;
        }
    }

    public class Konjanici1 : Sprite
    {
        public Konjanici1(int jb) : base("sprites\\Horseman1.jpg", 0, 0)
        {
            JedinstveniBroj = jb;
            Nsnagakonjistrijelci = 20;
            Nsnagakonji = 10;
            Nsnagalegionari = 5;
            Osnagakonjistrijelci = 5;
            Osnagakonji = 10;
            Osnagalegionari = 5;
            Ljudstvo = 1000;
            Moral = 100;
        }
    }
}
