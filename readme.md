Verifi
------

A simple verification system for .NET

Verifications are a little like unit tests.

Create a new Class Library project and add a reference to Verifi

The easiest way is `Install-Package Verifi`

Then you can add classes that inherit from `Verifi.Verification`. The classes should be named after the verification they are performing and will be transformed into something more human-friendly for display. i.e. `PaymentGatewayStatus` will become *Payment Status Gateway* at run time.

These classes should override the `DoRun()` method and make calls to the `AddError` or `AddNotice` methods. These calls will be displayed to the user immediately. If you add an error then the verification is considered failed.

Calls to `AddError` and `AddNotice` both accept a string description of what's going on and a context object. This object will have it's properties shown along with the notification in a serialized json format.

Once all verifications have been completed. A results report is displayed which lists which verifications passed, which ones failed and what the pass rate currently is.

For convenience with build systems the return value of the Verifi.exe will be the number of failed verifications (non-zero is usually considered failure) or a negative value if something catastrophic occurred.

You can specify command line arguments by adding them after the call to Verifi.exe in a name:value format. To add the argument to your verification decorate a string field with the `Arg(argumentName)` attribute.

Here's an example verification:

```
class PaymentGatewayStatus : Verification
{
	protected override DoRun()
	{
		var gateway = new PaymentGateway();
		var result = gateway.MakePayment(SAMPLE_CREDIT_CARD, SUCCESS_VALUE);
		if(result != null)
			AddNotice("Payment Gateway is working", new { result });
		else
			AddError("Payment Gateway is not returning results for test transaction");
	}
}
```

Note that if the call to `DoRun()` results in an exception then the verification is considered failed and the details of the exception displayed as the context.

See the sample project for more details.

Verifi is released under the MIT license http://www.opensource.org/licenses/MIT

Credits
-------

Special thanks go to http://mef.codeplex.com/ and http://james.newtonking.com/projects/json-net.aspx without which Verifi would probably not exist.