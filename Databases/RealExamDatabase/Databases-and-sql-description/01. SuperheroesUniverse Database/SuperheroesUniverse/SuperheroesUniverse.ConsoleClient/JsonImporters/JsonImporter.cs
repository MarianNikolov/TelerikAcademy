using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SocialNetwork.Data.UnitOfWorks;
using SuperheroesUniverse.ConsoleClient.JsonModels;
using SuperheroesUniverse.Models;

namespace SuperheroesUniverse.ConsoleClient.JsonImporters
{
    public class JsonImporter : IJsonImporter
    {
        private HashSet<string> addedPlanets = new HashSet<string>();
        private HashSet<string> addedCountries = new HashSet<string>();
        private HashSet<string> addedCity = new HashSet<string>();
        private HashSet<string> addedPowers = new HashSet<string>();
        private HashSet<string> addedFractions = new HashSet<string>();

        private IUnitOfWork unitOfWork;

        public JsonImporter(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Import()
        {
            ICollection<DataRoot> root =
                Directory
                .GetFiles(Directory.GetCurrentDirectory() + "/JsonFiles/")
                .Where(file => file.EndsWith("sample-data.json"))
                .Select(file => File.ReadAllText(file))
                .Select(str => JsonConvert.DeserializeObject<DataRoot>(str))
                .ToList();

            foreach (var superheros in root)
            {
                foreach (var superhero in superheros.data)
                {
                    var currentHero = new Superhero
                    {
                        Name = superhero.name,
                        SecretIdentity = superhero.secretIdentity,
                        Alignment = (AlignmentType)Enum.Parse(typeof(AlignmentType), superhero.alignment, true),
                        Story = superhero.story,
                    };

                    var currentPlanetName = superhero.city.planet;
                    Planet planetToAdd = null;

                    if (addedPlanets.Contains(currentPlanetName))
                    {
                        planetToAdd = this.unitOfWork.GetRepository<Planet>().All()
                            .Where(c => c.Name == currentPlanetName)
                            .FirstOrDefault();
                    }
                    else
                    {
                        planetToAdd = new Planet
                        {
                            Name = currentPlanetName
                        };

                        this.unitOfWork.GetRepository<Planet>().Add(planetToAdd);
                        addedPlanets.Add(currentPlanetName);
                    }

                    var currentCountryName = superhero.city.country;
                    Country CountryToAdd = null;

                    if (addedCountries.Contains(currentCountryName))
                    {
                        CountryToAdd = this.unitOfWork.GetRepository<Country>().All()
                            .Where(c => c.Name == currentCountryName)
                            .FirstOrDefault();
                    }
                    else
                    {
                        CountryToAdd = new Country
                        {
                            Name = currentCountryName
                        };

                        this.unitOfWork.GetRepository<Country>().Add(CountryToAdd);
                        addedCountries.Add(currentCountryName);
                    }

                    var currentCityName = superhero.city.name;
                    City cityToAdd = null;

                    if (addedCity.Contains(currentCityName))
                    {
                        cityToAdd = this.unitOfWork.GetRepository<City>().All()
                             .Where(c => c.Name == currentCityName)
                             .FirstOrDefault();
                    }
                    else
                    {
                        cityToAdd = new City
                        {
                            Name = currentCityName,
                        };

                        this.unitOfWork.GetRepository<City>().Add(cityToAdd);
                        addedCity.Add(currentCityName);
                    }

                    Power powerToAdd = null;
                    ICollection<Power> powerstoAdd = new HashSet<Power>();

                    foreach (var currentPower in superhero.powers)
                    {
                        if (addedPowers.Contains(currentPower))
                        {
                            powerToAdd = this.unitOfWork.GetRepository<Power>().All()
                                 .Where(c => c.Name == currentPower)
                                 .FirstOrDefault();

                            powerstoAdd.Add(powerToAdd);
                        }
                        else
                        {
                            powerToAdd = new Power
                            {
                                Name = currentPower,
                            };

                            this.unitOfWork.GetRepository<Power>().Add(powerToAdd);
                            addedPowers.Add(currentPower);
                            powerstoAdd.Add(powerToAdd);
                        }
                    }

                    Fraction fractionToAdd = null;
                    ICollection<Fraction> FractionstoAdd = new HashSet<Fraction>();

                    if (superhero.fractions != null)
                    {
                        foreach (var fraction in superhero.fractions)
                        {
                            if (addedPowers.Contains(fraction))
                            {
                                fractionToAdd = this.unitOfWork.GetRepository<Fraction>().All()
                                     .Where(c => c.Name == fraction)
                                     .FirstOrDefault();

                                powerstoAdd.Add(powerToAdd);
                            }
                            else
                            {
                                fractionToAdd = new Fraction
                                {
                                    Name = fraction
                                };

                                this.unitOfWork.GetRepository<Fraction>().Add(fractionToAdd);
                                addedPowers.Add(fraction);
                                FractionstoAdd.Add(fractionToAdd);
                            }
                        }
                    }

                    cityToAdd.Country = this.unitOfWork.GetRepository<Country>().All()
                        .Where(c => c.Name == currentCountryName).FirstOrDefault();

                    CountryToAdd.Planet = this.unitOfWork.GetRepository<Planet>().All()
                        .Where(c => c.Name == currentPlanetName).FirstOrDefault();

                    currentHero.SuperheroPowers = powerstoAdd;
                    currentHero.CityThatProtect = cityToAdd;
                    currentHero.SuperheroFractions = FractionstoAdd;

                    this.unitOfWork.GetRepository<Superhero>().Add(currentHero);

                    this.unitOfWork.SaveChanges();
                }
            }
        }
    }
}
