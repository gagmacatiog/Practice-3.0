using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database.Offline;
using System.Threading;

namespace Queuing_Application
{
    public class firebase_Connection
    {
        private const String databaseUrl = "https://usep-queue-app.firebaseio.com/";
        private const String databaseSecret = "xMkY2DmLnRefSl34kYlp8PWUzDwNmyJAvxLPygQ1";

        //private const String node = "Main_Queue/";
        private FirebaseClient firebase;
        private FirebaseOptions a;
        private FirebaseQuery b;
        public firebase_Connection()
        {

            this.firebase = new FirebaseClient(
                databaseUrl,
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(databaseSecret)
                });
        }
        public async Task TryFunction()
        {
            
            await firebase.Child("first_var").PostAsync(new _Queue_Info());
            await firebase.Child("first_var").Child("2nd_var").PostAsync(new _Queue_Info());

            //await firebase.Child("Counter").;
            //await firebase.Child("Queue_Info").DeleteAsync();
        }
        public async Task Retrieve(_Queue_Info q_info)
        {
            //ref.child('videos/videoId1').orderByChild('time')
            //await firebase.Child(node).OrderBy("ID").EqualTo(1).LimitToFirst(1).PutAsync<_Queue_Info>(q_info);
            //>await firebase.Child(node).OrderBy("ID").StartAt(5).EndAt(6).LimitToFirst(1).PutAsync<_Queue_Info>(q_info);
            //var cc = await firebase.Child(node).OrderBy("ID").LimitToFirst(2).OnceAsync<_Queue_Info>();
            //foreach (var b in cc) {
            //    Console.WriteLine($"{b.Key} is {b.Object.ID}m high.");
            //}
        }
        public async Task rr() {
            int x = 1;
            var observable = firebase.Child("test/").AsObservable<_Queue_Info>().Subscribe(d => Console.WriteLine(d.Key));
            async Task okAsync() {
                try
                {
                    while (x < 100)
                    {
                        x++;
                        _Queue_Info aa = new _Queue_Info { Servicing_Office = x };
                        await firebase.Child("test/").PostAsync<_Queue_Info>(aa);
                    }
                }
                catch (FirebaseException e)
                {
                    Console.Write("ERROR" + e);
                }
                finally
                {
                    //read this here
                    Thread.Sleep(10000);
                    _Queue_Info aa = new _Queue_Info { Servicing_Office = x };
                    await firebase.Child("test/").PostAsync<_Queue_Info>(aa);
                    await okAsync();
                }
            }
           await okAsync();


        }
        public async Task InsertMultiple()
        {
            int x = 1;
            for (x = 1; x <= 10; x++)
            {
                _Queue_Info aa = new _Queue_Info { Servicing_Office = x };
                await firebase.Child("Queue_Info/").PostAsync<_Queue_Info>(aa);
            }

        }
        public async Task Delete(_Queue_Info q_info)
        {
            //>await firebase.Child(node).Child(q_info.Key).DeleteAsync();

        }
        public async void App_Update_QueueInfo(int where, _Queue_Info q_info)
        {
            string node = "Queue_Info/";
            Console.WriteLine("App Update Child running");

            string key = "";
            var cc = await firebase.Child(node).OrderBy("Servicing_Office").StartAt(where).EndAt((where + 1)).LimitToFirst(1).OnceAsync<_Queue_Info>();
            foreach (var b in cc) { key = b.Key; }

            Console.WriteLine("Key returned is " + key);

            try { await firebase.Child(node).Child(key).PutAsync<_Queue_Info>(q_info); }
            catch (Exception e) { Console.Write("error ->" + e); }
            finally { Console.Write("Update finished."); }

        }
        //public async void Update(string key, _Queue_Info q_info)
        //{
        //    Console.WriteLine("Opening Update...");
        //    //>await firebase.Child(node).Child(key).PutAsync<_Queue_Info>(q_info);
        //    //>Console.WriteLine(node + key);
        //}
        public async Task App_Insert_MainQueue(_Main_Queue mq)
        {

    Console.Write("App Insert MainQueue running...");

            await firebase.Child("Main_Queue/").PostAsync<_Main_Queue>(mq);

    Console.Write("App Insert MainQueue done.");
        }
        public async Task App_Insert_QueueInfo(_Queue_Info q_info)
        {

    Console.Write("App Insert QueueInfo running...");

            await firebase.Child("Queue_Info/").PostAsync<_Queue_Info>(q_info);

    Console.Write("App Insert QueueInfo done.");
        }

        public async Task App_Insert_QueueTransaction(_Queue_Transaction qtr)
        {

    Console.Write("App Insert QueueTransaction running...");

            await firebase.Child("Queue_Transaction/").PostAsync<_Queue_Transaction>(qtr);

    Console.Write("App Insert QueueTransaction done.");
        }

    }
}
