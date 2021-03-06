using Mendes.Trucks.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Mendes.Trucks.Web.Controllers
{
	public class BaseController : Controller
	{
		public void ShowMessage(MessageType messageType, string message)
		{
			TempData.Remove(messageType.ToString());
			TempData.Add(messageType.ToString(), message);
		}

		public void ShowMessage(MessageType messageType, IEnumerable<string> messages)
		{
			TempData.Remove(messageType.ToString());
			TempData.Add(messageType.ToString(), messages);
		}

		public static SelectList GetEnumList(Type type, bool orderByValue = false)
		{
			var enumValues = Enum.GetValues(type);
			var texts = new List<string>();
			var values = new List<int>();

			foreach (Enum value in enumValues)
			{
				var memberInfo = value.GetType().GetMember(value.ToString());
				var attributes = (memberInfo.Length > 0)
					? (DisplayAttribute[])memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false)
					: null;

				texts.Add(attributes != null && attributes.Length == 1 ? attributes[0].Name : value.ToString());

				for (var i = 0; i < enumValues.Length; i++)
				{
					if (enumValues.GetValue(i)?.ToString() != value.ToString()) continue;

					values.Add((int)enumValues.GetValue(i));
					break;
				}
			}

			var list = texts.Select((t, i) => new SelectListItem
			{
				Text = t,
				Value = values[i].ToString(),
				Selected = false,
				Disabled = false
			}).ToList();

			return orderByValue
				? new SelectList(list.OrderBy(x => x.Value), "Value", "Text")
				: new SelectList(list.OrderBy(x => x.Text), "Value", "Text");
		}
	}
}
