using Verifi;

namespace Sample.Verifications
{
    class TestPassing: Verification
    {
        protected override void DoRun()
        {
            AddNotice("A basic note", new { someArg = "A Value", complex = new { firstName = "Mike", lastName = "Minutillo" } });
        }
    }

    class TestFailing : Verification
    {
        protected override void DoRun()
        {
            AddError("Stuff went wrong!", new { whatWentWrong = "This test failed", why = "this test was DOOMED!" });
        }
    }

    class RequiresArg : Verification
    {
        [Arg("SomeArg")]
        string SomeArg = null;

        protected override void DoRun()
        {
            if (SomeArg == null)
                AddError("You need SomeArg");
            else
                AddNotice("SomeArg was set", new { SomeArg });
        }
    }


}
