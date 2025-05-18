using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Exam_09_07_2023_Skateboard.Modules
{
    public class SkateboardShop
    {
        private string name;
        private List<Skateboard> skateboards;

        public SkateboardShop(string name)
        {
            Name = name;
            this.skateboards = new List<Skateboard>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                // // Regex validation
                // Validator.ValidateCapitalSmall(value);

                if (!Regex.IsMatch(value, "^([A-Za-z])+$"))
                {
                    throw new ValidationException("Input values should be a capital or lower latin letter!");
                }

                this.name = value;
            }
        }

        public List<Skateboard> Skateboards
        {
            get
            {
                return this.skateboards;
            }
            set
            {
                this.skateboards = value;
            }
        }

        public void AddSkateboard(string model, double price)
        {
            Skateboard skateboard = new Skateboard(model, price);
            skateboards.Add(skateboard);
        }

        public double AveragePriceInRange(double start, double end)
        {
            return skateboards.Where(x => x.Price >= start && x.Price <= end).Average(x => x.Price);
        }

        public List<string> FilterSkateboardsByPrice(double price)
        {
            return skateboards.Where(x => x.Price < price).Select(x => x.Model).ToList();
        }

        public List<Skateboard> SortAscendingByModel()
        {
            return skateboards.OrderBy(x => x.Model).ToList();
        }

        public List<Skateboard> SortDescendingByPrice()
        {
            return skateboards.OrderByDescending(x => x.Price).ToList();
        }

        public bool CheckSkateboardIsInShop(string model)
        {
            return skateboards.Any(x => x.Model == model);
        }

        public string[] ProvideInformationAboutAllSkateboards()
        {
            return skateboards.Select(x => x.ToString()).ToArray();

            // string[] info = new string[skateboards.Count];

            // for (int i = 0; i < skateboards.Count; i++)
            // {
            //     info[i] = skateboards[i].ToString();
            // }

            // return info;
        }
    }
}