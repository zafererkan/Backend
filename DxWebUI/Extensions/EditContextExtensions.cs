using FluentValidation;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections;
using System.Reflection;

namespace Sobis.BlazorWebUI.Client.Extensions
{
    public static class EditContextExtensions
    {
        /// <summary>
        /// returns true if all validation messages are less severe as <paramref name="severity"/> parameter
        /// e.g. IsValid(Severity.Warning) returns false if there are any warnings or errors
        /// </summary>
        public static bool IsValid(this EditContext editContext, Severity severity)
        {
            foreach (var message in editContext.GetValidationMessages())
            {
                var actualSeverity = message.StartsWith("[Info]") ? Severity.Info
                    : message.StartsWith("[Warning]") ? Severity.Warning
                    : Severity.Error;

                if (actualSeverity <= severity) //error = 0, warning = 1
                {
                    return false;
                }
            }
            return true;
        }

        public static bool HasNoErrorValidationMessages(this EditContext editContext)
            => IsValid(editContext, Severity.Error);

        /// <summary>
        /// returns true any validation message has <see cref="Severity.Error"/> severity
        /// e.g. returns false if there are no errors or all messages are less severe (warnings or infos)
        /// <summary>
        public static bool HasErrorValidationMessage(this EditContext editContext)
           => !IsValid(editContext, Severity.Error);

        public static void ClearValidationMessages(this EditForm editForm, bool revalidate = false, bool markAsUnmodified = false)
        {
            var bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            object GetInstanceField(Type type, object instance, string fieldName)
            {
                var fieldInfo = type.GetField(fieldName, bindingFlags);
                return fieldInfo.GetValue(instance);
            }

            var editContext = editForm.EditContext == null
                ? GetInstanceField(typeof(EditForm), editForm, "_fixedEditContext") as EditContext
                : editForm.EditContext;

            var fieldStates = GetInstanceField(typeof(EditContext), editContext, "_fieldStates");
            var clearMethodInfo = typeof(HashSet<ValidationMessageStore>).GetMethod("Clear", bindingFlags);

            foreach (DictionaryEntry kv in (IDictionary)fieldStates)
            {
                var messageStores = GetInstanceField(kv.Value.GetType(), kv.Value, "_validationMessageStores");
                clearMethodInfo.Invoke(messageStores, null);
            }

            if (markAsUnmodified)
                editContext.MarkAsUnmodified();

            if (revalidate)
                editContext.Validate();
        }
    }
}
