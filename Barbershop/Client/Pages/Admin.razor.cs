using Barbershop.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Barbershop.Client.Pages;

	public partial class Admin : ComponentBase
{

	private BarberServDto Edserv = new BarberServDto();
	private List<BarberServDto> allservers = new List<BarberServDto>();
	private bool editMode = false;
	private async Task Submit()
	{
		if (editMode)
		{
			await _Client.client.PutAsJsonAsync("Updateservs", Edserv);
			Edserv = new();
			editMode = false;
		}
		else
		{
			await _Client.client.PutAsJsonAsync("Updateservs", Edserv);
			Edserv = new();
		}
	}
	protected override async Task OnInitializedAsync()
	{
		allservers = await _Client.client.GetFromJsonAsync<List<BarberServDto>>("Getallservs");
	}
	private void SelectProduct(int id)
	{
		Edserv = allservers.First(s => s.Id == id);
		editMode = true;
	}
	private async void RemoveProduct(int id)
	{
		await _Client.client.DeleteAsync($"Deleteserv/{id}");
		Edserv = new();
		editMode = false;
	}
}




