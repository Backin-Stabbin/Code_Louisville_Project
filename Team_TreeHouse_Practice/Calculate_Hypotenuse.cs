using System;

class MyProgram {
    static void Main () {

        Double mySide1;
        Double mySide2;
        
        Console.Write ("What is length of Side 'A'? ");
        String s1 = Console.ReadLine ();
        Console.Write ("What is length of Side 'B'? ");
        String s2 = Console.ReadLine ();

        mySide1 = Double.Parse (s1);
        mySide2 = Double.Parse (s2);

        RightTriangle triangle = new RightTriangle (mySide1, mySide2);
        Double myHypo = RightTriangle.CalculateHypotenuse (triangle);

        Console.WriteLine ("The Hypotenuse is: " + myHypo);
        Console.WriteLine ();
        Console.WriteLine ("Press any key to close!");
        Console.ReadKey ();
    }
}

class RightTriangle {
    public Double Side1;
    public Double Side2;

    public RightTriangle (Double mySide1, Double mySide2) {
        Side1 = mySide1;
        Side2 = mySide2;
    }

    public static Double CalculateHypotenuse (RightTriangle myTriangle) {
        Double hypo;
        hypo = Math.Sqrt (Math.Pow (myTriangle.Side1, 2) + Math.Pow (myTriangle.Side2, 2));
        return hypo;
    }
}
