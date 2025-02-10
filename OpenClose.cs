using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{

    /*
     *  Consider a scenario where you build a product and product filter.
     *  The class ProductFilter violates Open Close desgin pricniple.
     *  A class should be open for extension and closed for modification.
     */
    internal class OpenClose
    {
        public void Start()
        {
            var cashew = new Product("Cashew", Color.White, Size.Regular);
            var Pista = new Product("Pista", Color.Red, Size.Small);
            var badam = new Product("Badam", Color.Brown, Size.Large);

            Product[] items = {cashew, Pista, badam};

            // Below implementation violate open-close principle
            var pf = new ProductFilter();
            Console.WriteLine("White Products:");
            foreach (var p in pf.FilterByColor(items, Color.White))
                Console.WriteLine($"- {p.Name} is White");

            var bpf = new BetterFilter();
            Console.WriteLine("White Products:");
            foreach(var p in bpf.Filter(items, new ColorSpecification(Color.White)))
                Console.WriteLine($"- {p.Name} is White");

            Console.WriteLine("Small and Red items");
            foreach(var p in bpf.Filter(
                items,
                new AndSpecification<Product>(
                    new ColorSpecification(Color.Red),
                    new SizeSpecification(Size.Small)
                    )))
                Console.WriteLine($"- {p.Name}");

        }
    }

    public enum Color
    {
        Red, Green, Blue, White, Brown
    }

    public enum Size
    {
        Small, Regular, Medium, Large, Huge
    }
    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            this.Name = name;
            this.Color = color;
            this.Size = size;
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var product in products)
                if (product.Size == size)
                    yield return product;
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var product in products)
                if (product.Color == color)
                    yield return product;
        }
    }

    // Implementing open-close principle
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;

        public ColorSpecification(Color color)
        {
            this.color = color;   
        }

        public bool IsSatisfied(Product product)
        {
            return product.Color == color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private Size size;

        public SizeSpecification(Size size)
        {
            this.size = size;
        }

        public bool IsSatisfied(Product product)
        {
            return product.Size == size;
        }    
    }
    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach( var item in items)
                if(spec.IsSatisfied(item))
                    yield return item;
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> spec1, spec2;

        public AndSpecification(ISpecification<T> spec1, ISpecification<T> spec2)
        {
            this.spec1 = spec1;
            this.spec2 = spec2; 
        }

        public bool IsSatisfied(T t)
        {
            return spec1.IsSatisfied(t) && spec2.IsSatisfied(t);
        }
    }
}
