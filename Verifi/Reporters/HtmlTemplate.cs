﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 10.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Verifi.Reporters
{
    using System;
    
    
    #line 1 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public partial class HtmlTemplate : HtmlTemplateBase
    {
        public virtual string TransformText()
        {
            this.Write(@"<!DOCTYPE HTML>
<html>
<head>
	<style>
		.verification { border: 3px solid Black; margin: 5px 0; padding: 10px;}
		.failed.verification { border-color:#FBC2C4; }
		.failed.verification h3 { color:#8a1f11; }
		
		.successful.verification { background:#E6EFC2;border-color:#C6D880; }
		.successful.verification h3 { color:#264409; }
		
		.notice {padding:.8em;margin-bottom:1em;border:2px solid #ddd;}
		.fail.notice {background:#FBE3E4;color:#8a1f11;border-color:#FBC2C4;}
		.note.notice { background:#FFF6BF;color:#514721;border-color:#FFD324;}
		
		#failed { background-color: #8a1f11; width: 100%; }
		#succeeded { background-color: #264409; width: ");
            
            #line 18 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Results.PassRate));
            
            #line default
            #line hidden
            this.Write("% }\r\n\t\t\r\n\t\t#stats { padding:.8em;margin-bottom:1em;border:2px solid #ddd;\t}\r\n\t\t\r\n" +
                    "\t</style>\r\n</head>\r\n<body>\r\n\t<div id=\"stats\">\r\n\t\t<h1>Verifi: ");
            
            #line 26 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DateTime.Now.ToLongDateString()));
            
            #line default
            #line hidden
            this.Write(" - ");
            
            #line 26 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DateTime.Now.ToShortTimeString()));
            
            #line default
            #line hidden
            this.Write("</h1>\r\n\t\t<div id=\"failed\">\r\n\t\t\t<div id=\"succeeded\">&nbsp;\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t" +
                    "\tPassed: <strong>");
            
            #line 31 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Results.PassCount));
            
            #line default
            #line hidden
            this.Write("</strong> - Failed: <strong>");
            
            #line 31 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Results.FailCount));
            
            #line default
            #line hidden
            this.Write("</strong> - \r\n\t\tTotal: <strong>");
            
            #line 32 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Results.Total));
            
            #line default
            #line hidden
            this.Write("</strong> - Pass rate: <strong>");
            
            #line 32 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Results.PassRate.ToString("0.##")));
            
            #line default
            #line hidden
            this.Write("%</strong><br/>\r\n\t</div>\r\n\r\n\t");
            
            #line 35 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
 foreach(var verification in Results.Failed) { 
            
            #line default
            #line hidden
            this.Write("\t\t<div class=\"verification failed\">\r\n\t\t\t<h3>");
            
            #line 37 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(verification.Name));
            
            #line default
            #line hidden
            this.Write("</h3>\r\n\t\t\t");
            
            #line 38 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
 foreach(var notification in Notifications[verification]) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t<div class=\"notice ");
            
            #line 39 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(notification.Prefix.ToLower()));
            
            #line default
            #line hidden
            this.Write("\">\r\n\t\t\t\t\t");
            
            #line 40 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(notification.Description));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 41 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
 if(notification.Context != null) { 
            
            #line default
            #line hidden
            this.Write("<pre>\r\n");
            
            #line 43 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ToJson(notification.Context)));
            
            #line default
            #line hidden
            this.Write("\r\n</pre>\r\n");
            
            #line 45 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t</div>\r\n\t\t\t");
            
            #line 47 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t</div>\r\n\r\n\t");
            
            #line 50 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\r\n\t");
            
            #line 53 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
 foreach(var verification in Results.Passed) { 
            
            #line default
            #line hidden
            this.Write("\t\t<div class=\"verification successful\">\r\n\t\t\t<h3>");
            
            #line 55 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(verification.Name));
            
            #line default
            #line hidden
            this.Write("</h3>\r\n\t\t\t");
            
            #line 56 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
 foreach(var notification in Notifications[verification]) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t<div class=\"notice ");
            
            #line 57 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(notification.Prefix.ToLower()));
            
            #line default
            #line hidden
            this.Write("\">\r\n\t\t\t\t\t");
            
            #line 58 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(notification.Description));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 59 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
 if(notification.Context != null) { 
            
            #line default
            #line hidden
            this.Write("<pre>\r\n");
            
            #line 61 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ToJson(notification.Context)));
            
            #line default
            #line hidden
            this.Write("\r\n</pre>\r\n");
            
            #line 63 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t</div>\r\n\t\t\t");
            
            #line 65 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t</div>\r\n\r\n\t");
            
            #line 68 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("</body>\r\n</html>\r\n\r\n\r\n\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 74 "C:\Data\GitHub\Verifi\Verifi\Reporters\HtmlTemplate.tt"


	public RunResults Results { get; set; }
	public System.Linq.ILookup<Verification, Notification> Notifications { get; set; }

	public string ToJson(object context)
	{
		var serializer = Newtonsoft.Json.JsonSerializer.Create(new Newtonsoft.Json.JsonSerializerSettings());
		var sb = new System.Text.StringBuilder();

        var writer = new Newtonsoft.Json.JsonTextWriter(new System.IO.StringWriter(sb));
        writer.Formatting = Newtonsoft.Json.Formatting.Indented;

        serializer.Serialize(writer, context);

		return sb.ToString();
	}

        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public class HtmlTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
