namespace AccessModifiers
{
    //by default class has minimum possible access hence internal.
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}


/*
 
    Caller's location	                    public  protected   protected   internal    private     private
                                                    internal			                protected	
    Within the class	                      ✔️	       ✔️	        ✔️	       ✔️	        ✔️	       ✔️
    Derived class (same assembly)	          ✔️	       ✔️	        ✔️	       ✔️	        ✔️	       ❌
    Non-derived class (same assembly)	      ✔️	       ✔️	        ❌	       ✔️	        ❌	       ❌
    Derived class (different assembly)	      ✔️	       ✔️	        ✔️	       ❌	        ❌	       ❌
    Non-derived class (different assembly)	  ✔️	       ❌	        ❌	       ❌	        ❌	       ❌
 
 */