using Machine.Specifications;

namespace app.specs
{
  public class CalculatorSpecs
  {
    public class when_adding_two_numbers
    {
      //assert
      It should_return_the_sum = () =>
        Calculator.add(2, 3).ShouldEqual(5);
        
    }   
  }
}