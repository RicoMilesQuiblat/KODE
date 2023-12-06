using System.Collections;
using System.Collections.Generic;
using Firebase.Auth; 
using UnityEngine;
using Firebase.Firestore;
using Firebase.Extensions;
using System.Threading.Tasks;
public class SlimeSpawnController : MonoBehaviour
{
    public GameObject Scroll1;
    public GameObject Scroll2;
    public GameObject Scroll3;
    public GameObject Scroll4;
    public GameObject Scroll5;

    public string getUserId() {
        if (FirebaseAuth.DefaultInstance != null)
            return FirebaseAuth.DefaultInstance.CurrentUser.UserId; 
        else
            return null;
    }

    public async Task getUserDataAsync() {
        string uid = getUserId();
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        DocumentReference docRef = db.Collection("user_data").Document(uid);
        DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
        if (snapshot.Exists)
        {
            Debug.Log($"Document data for {snapshot.Id} document:");
            Dictionary<string, object> city = snapshot.ToDictionary();
            foreach (KeyValuePair<string, object> pair in city)
            {
                //rico naa diri ang values mao ni ang pag sunod sa output:
                //countJournal: 3, hp: 69.9, lives: 3, objectiveIndex: 1 so una ang journal nya hp nya lives nya last index
                Debug.Log($"{pair.Key}: {pair.Value}");
            }
        }
        else
        {
            Debug.Log($"Document {snapshot.Id} does not exist!");
        }
    }

    public async Task setUserDataAsync() {
        string uid = getUserId();
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        CollectionReference citiesRef = db.Collection("user_data");

        try
        {
            await citiesRef.Document(uid).SetAsync(new Dictionary<string, object>()
            {
                //save data ni rico
                { "countJournal", 2 },
                { "hp", 36.9 },
                { "lives", 1 },
                { "objectiveIndex", 3 }
            });
            Debug.Log("Data successfully set!");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error setting user data: {e.Message}");
        }
    }

    public void callFetchMethod() {
        _ = getUserDataAsync();
    }

    public void callSaveMethod() {
        _ = setUserDataAsync();
    }
}
