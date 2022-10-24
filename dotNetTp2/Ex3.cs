using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace dotNetTp2
{
    public class Point3D: IComparable<Point3D>
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Point3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void Bouger(float dx, float dy, float dz)
        {
            X += dx;
            Y += dy;
            Z += dz;
        }

        public override string ToString()
        {
            return "[Point3D x:" + X + " , " + "y: " + Y + ", Z:" + Z + "]\n";
        }


        public int CompareTo(Point3D? other)
        {
            if (other == null )
            {
                return 1;
            }
            if(X == other.X && Y == other.Y && Z == other.Z) { return 0; }
            return -1;
        }
    }
    public abstract class Forme
    {
        public Point3D? GravityCenter { get; set; }

        public Forme(Point3D gravity)
        {
            GravityCenter = gravity;
        }
        public virtual double calculerSurface() { return 0; }
        public virtual double calculerVolume() { return 0; }

    }
    public class Brique : Forme
    {
        public float largeur { get; set; }
        public float longueur { get; set; }
        public float hauteur { get; set; }

        public Brique(Point3D gravity, float largeur, float longueur, float hauteur) : base(gravity)
        {
            this.largeur = largeur;
            this.longueur = longueur;
            this.hauteur = hauteur;

        }
        public override double calculerSurface() { return largeur+longueur+hauteur; }
        public override double calculerVolume() { return largeur*longueur*hauteur; }

        public override string ToString()
        {
            return "[Brique \n\tcentre de gravité: "+GravityCenter+"\n\tlargeur: "+largeur+"\n\tlongueur: "+longueur+"\n\thauteur: "+hauteur+"\n]";
        }
    }
 
    public sealed class Cube : Brique
    {
        public Cube(Point3D gravity, float size) : base(gravity, size, size, size) { }
        public override string ToString()
        {
            return "[Cube \n\tcentre de gravité: " + GravityCenter + "\n\tsize: " +largeur+"\n]";
        }
    }

    public class Boule : Forme
    {
        public float rayon { get; set; }
        public Boule(Point3D gravity, float rayon) : base(gravity)
        {
            this.rayon = rayon;
        }
        public override double calculerSurface() { return rayon * 2*Math.PI; }
        public override double calculerVolume() { return rayon*rayon*Math.PI; }

        public override string ToString()
        {
            return "[Boule \n\tcentre de gravité: " + GravityCenter + "\n\trayon: " + rayon + "\n]";
        }

        public bool Equals(Boule b) { 
            return b.GravityCenter == GravityCenter && b.rayon == rayon;
        }
    }
    
    public class Ex3
    {
        public static void Main()
        {
            Point3D point = new Point3D(5f, 3f, 5f);
            Brique b = new Brique(point, 5.0f, 5.0f, 5.0f);
            Console.WriteLine(b);
            Console.WriteLine("surface "+b.calculerSurface());
            Console.WriteLine("volume " + b.calculerVolume());

            Point3D point1 = new Point3D(5f, 3f, 5f);
            Boule sphere1 = new Boule(point1, 5.0f);
            Boule sphere2 = new Boule(point1, 5.0f);

            Console.WriteLine(sphere1);
            Console.WriteLine("surface " + sphere1.calculerSurface());
            Console.WriteLine("volume " + sphere1.calculerVolume());
            Console.WriteLine(sphere2);
            Console.WriteLine("surface " + sphere2.calculerSurface());
            Console.WriteLine("volume " + sphere2.calculerVolume());

            if (sphere1.Equals(sphere2))
            {
                Console.WriteLine("the two shpere are equal");
            }

        }
    }

}

