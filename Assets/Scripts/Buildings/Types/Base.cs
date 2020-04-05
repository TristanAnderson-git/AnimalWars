using TMPro;

public class Base : Building
{
    public static Hut hut;
    public static Storage storage;
    public static ResourceSink sink;

    public TextMeshProUGUI[] resourceUI;

    public override void Init()
    {
        hut = GetComponent<Hut>();
        storage = GetComponent<Storage>();
        sink = GetComponent<ResourceSink>();

        hut.health = storage.health = sink.health = health;
        hut.owner = storage.owner = sink.owner = owner;
        hut.refreshPerformTime = storage.refreshPerformTime = sink.refreshPerformTime = refreshPerformTime;

        hut.Init();

        // Spawn in starting units
        for (int i = 0; i < 5; i++)
            hut.Perform();

        StartTask();
    }

    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            resourceUI[i].SetText(":" + storage.resources[i]);
        }
    }

    public override void Die()
    {
        // Game Over
        
        Destroy(gameObject);
    }

    public override void Perform()
    {
        if (GameController.players[owner].ownedUnitCount < 5)
            hut.Perform();

        sink.Perform();
        storage.DepositRecource(sink);
        storage.Perform();
    }
}
