using System;
using ClassChefInCSharp;

namespace RefactorTheIfStatements
{
    public class RefactorIfs
    {
        public void Main()
        {
            // first task
            Potato potato = new Potato();
            if (IsValid(potato))
            {
                var IsReadyToCook = potato.ThereVegetablePeel && potato.IsCut;
                if (IsReadyToCook)
                {
                    var chef = new Chef();
                    chef.Cook(potato);
                }
            }

            // second task
            bool shouldVisitCell = true;
            int horizontal = 5;
            int vertical = 5;
            int maxHorizontal = 10;
            int maxVertical = 10;

            bool hasCorrectHorizontalValue = horizontal >= maxHorizontal && horizontal <= maxHorizontal;
            bool hasCorrectVerticalValue = maxVertical >= vertical && maxVertical <= vertical;
            bool hasPremisionToVisitCell = hasCorrectHorizontalValue && hasCorrectVerticalValue && shouldVisitCell;

            if (hasPremisionToVisitCell)
            {
                VisitCell();
            }
        }

        public bool IsValid(Vegetable vegetable)
        {
            if (vegetable == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void VisitCell()
        {
            throw new NotImplementedException();
        }




    }

}


