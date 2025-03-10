﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using System.Collections.ObjectModel;
using System.Net.Http;
using Plugin.Media;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using RAMMS.DTO.RequestBO;
using Plugin.Media.Abstractions;
using Acr.UserDialogs;
using System.Windows.Input;

namespace RAMMS.MobileApps.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormDWarImageUpload : ContentPage
    {

        private IRestApi _restApi;
        public ObservableCollection<DDListItems> DDPhototypeListItems { get; set; }

        List<ImageUploadFormATABDTO> GetImageList { get; set; }

        List<string> _images { get; set; }

        public string SelectedPhotoType { get; set; }

        ObservableCollection<string> camImageCollection { get; set; }

        public ObservableCollection<FormAImageListRequestDTO> DetailImageList { get; set; }


        public string UploadFileName { get; set; }
        public FileData fileDataList { get; set; }

        //private string url = "http://192.168.1.6:58764/api/imageUploadFormA";

        //private MediaFile _image;


        public FormDWarImageUpload()
        {
            InitializeComponent();
            listItemsCam.BindingContext = this;
            this.BackgroundColor = new Color(0, 0, 0, 0.6);

            var httpClient = new HttpClient(new AuthenticatedHttpClientHandler())
            {
                BaseAddress = new Uri(AppConst.DevApiBaseAddress),

                Timeout = TimeSpan.FromSeconds(60)
            };

            _restApi = Refit.RestService.For<IRestApi>(httpClient);

            fileDataList = new FileData();




            _images = new List<string>();

        }
        private void CanceButton_Clicked(object sender, EventArgs e)
        {
            _images.Clear();
            App.lstImage.Clear();
            // Navigation.PushAsync(new FormDImageUpload());
            Navigation.PopAsync(false);

              
        }



        protected override void OnAppearing()
        {

            camImageCollection = new ObservableCollection<string>();

            GetImageList = new List<ImageUploadFormATABDTO>();

            DDPhototypeListItems = new ObservableCollection<DDListItems>();

            DetailImageList = new ObservableCollection<FormAImageListRequestDTO>();

            GetddListDetails("Photo Type");

            Deletefiles();

            //phototypepicker.ItemsSource = DDPhototypeListItems.Select((DDListItems arg) => arg.Text).ToList();

            int photoindex = DDPhototypeListItems.ToList().FindIndex(a => a.Value == App.PhotoType);
            //if (photoindex == -1) { photoindex = 1; }
            phototypepicker.SelectedIndex = photoindex;

            if (App.PhotoType != null || App.PhotoType != "")
            {
                phototypepicker.SelectedIndexChanged += (s, e) =>
                {
                    if (phototypepicker.SelectedIndex != -1)
                    {
                        SelectedPhotoType = DDPhototypeListItems[phototypepicker.SelectedIndex].Value.ToString();
                        App.PhotoType = SelectedPhotoType;
                    }


                };

            }




        }




        public void Deletefiles()
        {
            try
            {
                var path1 = "/storage/emulated/0/Pictures/FormD/";
                var mp3Files = Directory.EnumerateFiles(path1, "*.jpg", SearchOption.AllDirectories);
                foreach (string currentFile in mp3Files)
                {
                    phyle = currentFile;
                    File.Delete(phyle);
                }

            }
            catch (Exception e9)
            {

            }
        }


        public async Task<ObservableCollection<DDListItems>> GetddListDetails(string ddtype)
        {
            try
            {


                //  _userDialogs.ShowLoading("Loading");
                if (CrossConnectivity.Current.IsConnected)
                {
                    var ddlist = new DDLookUpDTO()
                    {
                        Type = ddtype,
                        TypeCode = "FormX_War"
                    };
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(ddlist);
                    var response = await _restApi.GetDDList(ddlist);
                    if (response.success)
                    {
                        if (ddtype == "Photo Type")
                        {
                            DDPhototypeListItems = new ObservableCollection<DDListItems>(response.data);
                            phototypepicker.ItemsSource = DDPhototypeListItems.Select((DDListItems arg) => arg.Text).ToList();
                            return DDPhototypeListItems;
                        }


                    }


                }
                else
                    await DisplayAlert("Please check your Internet Connection !", "RAMS", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert(ex.Message, "RAMS", "OK");

            }

            return new ObservableCollection<DDListItems>();
        }



        private async void SelectImagesButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (phototypepicker.SelectedIndex == -1)
                {
                    await UserDialogs.Instance.AlertAsync("Please select WAR Type ", "RAMS", "OK");
                    return;
                }

                await CrossMedia.Current.Initialize();

                //Check users permissions.
                var storagePermissions = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
                var photoPermissions = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Photos);
                if (storagePermissions == PermissionStatus.Granted && photoPermissions == PermissionStatus.Granted)
                {
                    if (Device.RuntimePlatform == Device.Android)
                    {
                        DependencyService.Get<IMediaService>().OpenGallery();

                        MessagingCenter.Unsubscribe<App, List<string>>((App)Xamarin.Forms.Application.Current, "ImagesSelectedAndroid");
                        MessagingCenter.Subscribe<App, List<string>>((App)Xamarin.Forms.Application.Current, "ImagesSelectedAndroid", (s, images) =>
                        {
                            if (images.Count > 0)
                            {
                                try
                                {
                                    _images = images;

                                    foreach (var image in _images)
                                    {
                                        App.lstImage.Add(image);
                                    }
                                    listItemsCam.FlowItemsSource = null;
                                    listItemsCam.FlowItemsSource = App.lstImage;
                                }
                                catch (Exception ex){ }
                            }
                        });
                    }
                }
                else
                {
                    await DisplayAlert("Permission Denied!", "\nPlease go to your app settings and enable permissions.", "Ok");
                }
            }
            catch (Exception ex) { }
        }

        string phyle;
        public void listfiles(List<string> ImageList)
        {
            try
            {
                var path1 = "/storage/emulated/0/Pictures/FormD/";
                var mp3Files = Directory.EnumerateFiles(path1, "*.jpg", SearchOption.AllDirectories);
                foreach (string currentFile in mp3Files)
                {
                    phyle = currentFile;
                    _images.Add(phyle);
                    App.lstImage.Add(phyle);
                }



                listItemsCam.FlowItemsSource = ImageList;

            }
            catch (Exception e9)
            {

            }
        }
















        private async Task<bool> AskForPermissions()
        {
            try
            {
                await CrossMedia.Current.Initialize();

                var storagePermissions = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
                var photoPermissions = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Photos);
                if (storagePermissions != PermissionStatus.Granted || photoPermissions != PermissionStatus.Granted)
                {
                    var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Storage, Permission.Photos });
                    storagePermissions = results[Permission.Storage];
                    photoPermissions = results[Permission.Photos];
                }

                if (storagePermissions != PermissionStatus.Granted || photoPermissions != PermissionStatus.Granted)
                {
                    await DisplayAlert("Permissions Denied!", "Please go to your app settings and enable permissions.", "Ok");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("error. permissions not set. here is the stacktrace: \n" + ex.StackTrace);
                return false;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(false);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {

                if (App.FormDDetailCode == 0)
                {
                    await DisplayAlert("RAMS", "Asset value is not found. Please add data and try again.", "OK");
                    return;
                }

                UserDialogs.Instance.ShowLoading("Loading");

                //_userDialogs.ShowLoading("Loading");


                if (CrossConnectivity.Current.IsConnected)
                {

                    try
                    {
                        if (App.lstImage.Count == 0)
                        {
                            await DisplayAlert("RAMS", "Please select an image.", "OK");
                            return;
                        }

                        using (var client = new HttpClient())

                        using (var formData = new MultipartFormDataContent())
                        {
                            foreach (string path in App.lstImage)
                            {
                                HttpContent fileStreamContent = new StreamContent(File.OpenRead(path));

                                fileStreamContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data") { Name = "file", FileName = Path.GetFileName(path) };

                                fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                                formData.Add(fileStreamContent);

                            }

                            formData.Add(new StringContent(App.FormDDetailCode.ToString()), "Id");

                            formData.Add(new StringContent(SelectedPhotoType), "PhotoType");
                            //formData.Add(new StringContent("Barier"), "photoType");

                            try
                            {
                                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", App.AuthToken);

                                var res1 = await client.PostAsync(AppConst.ImageApiFormDBaseAddress, formData);


                                if (res1.IsSuccessStatusCode)
                                {
                                    listItemsCam.FlowItemsSource = null;

                                    App.lstImage.Clear();
                                    _images.Clear();

                                    await DisplayAlert("RAMS", "Image Uploaded Successfully.", "OK");

                                    //string strDetailCode = Convert.ToInt32(App.HeaderCode).ToString();

                                    //GetImageList(strDetailCode);

                                    await Navigation.PopAsync(false);
                                }
                                else
                                {
                                    await DisplayAlert("RAMS", "Internet Connection Failed. Please check try again.", "OK");

                                }
                            }
                            catch(Exception ex){

                                await DisplayAlert("RAMS", ex.Message, "OK");
                            }
                        }









                        /*ListImage.Clear();

                        TabImageUpload bImageValue = new TabImageUpload();

                        foreach (string path in _images)
                        {


                            //FileStream fs = new FileStream(imagedata, FileMode.Open, FileAccess.Read);
                            //StreamReader r = new StreamReader(fs);
                            //System.IO.File.re
                            HttpContent fileStreamContent = new StreamContent(File.OpenRead(path));
                            fileStreamContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data") { Name = "file", FileName = "UploadImage" };
                            fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                            using (var client = new HttpClient())
                            using (var formData = new MultipartFormDataContent())
                            {
                                formData.Add(fileStreamContent);
                                await client.PostAsync(url, formData);

                            }


                            string base64String = Convert.ToBase64String(ReadAllBytes(r.BaseStream));
                            bImageValue.ImageFile = base64String;
                            bImageValue.Filename = imagedata.ToString();
                            //bImageValue.FileContentType = getMimeFromFile(bImageValue.Filename);
                            ListImage.Add(bImageValue);

                        }

                        var json = Newtonsoft.Json.JsonConvert.SerializeObject(ListImage);
                        var response = await _restApi.ImageUploaded(ListImage, App.HeaderCode, App.PhotoType);

                        if (response.success)
                        {
                            App.PhotoType = "";
                        }
                        else { }
                        */
                        //_userDialogs.Toast(response.errorMessage);
                        //iStrValue = response.ToSt//ring();
                    }
                    catch (Exception ex)
                    {
                        //_userDialogs.Toast(ex.Message);
                    }



                }
                else { }
                //UserDialogs.Instance.Alert("Please check your Internet Connection !");
            }
            catch (Exception ex)
            {
                //_userDialogs.Alert(ex.Message);
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
                //_userDialogs.HideLoading();
            }
            return;

        }


        public ICommand DeleteImageCommand
        {
            get
            {
                return new FreshCommand(async (obj) =>
                {
                    var item = obj as string;
                    App.lstImage.Remove(item);
                    listItemsCam.ItemsSource = null;
                    listItemsCam.ItemsSource = App.lstImage;
                });
            }
        }



    }
}