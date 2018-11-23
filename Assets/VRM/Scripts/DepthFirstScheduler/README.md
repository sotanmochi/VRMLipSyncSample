# DepthFirstScheduler(�[���D��X�P�W���[���[)
����́AUnity5.6��Task���������Ƃ�⊮���邽�߂̃��C�u�����ł��B
�@�\���Ƀ^�X�N��g�ݗ��ĂāA�[���D��ŏ������܂��B

* �^�X�N�̎��s�X�P�W���[���[(Unity���C���X���b�h�⃁�C���X���b�h)���w��ł���

# �g����

```cs
var schedulable = new Schedulable<Unit>();

schedulable
    .AddTask(Scheduler.ThreadPool, () => // �q���̃^�X�N��ǉ�����
    {
        return glTF_VRM_Material.Parse(ctx.Json);
    })
    .ContinueWith(Scheduler.MainThread, gltfMaterials => // �Z��̃^�X�N��ǉ�����
    {
        ctx.MaterialImporter = new VRMMaterialImporter(ctx, gltfMaterials);
    })
    .Subscribe(Scheduler.MainThread, onLoaded, onError);
    ;
```

# Schedulable<T>
T�^�̌��ʂ�Ԃ��^�X�N�B

## AddTask(IScheduler scheduler, Func<T> firstTask) 

�q���̃^�X�N��ǉ�����B

ToDo: ��ڂ̎q���Ɉ�����n����i������

## ContinueWith

## ContinueWithCoroutine

## OnExecute

���I�Ƀ^�X�N��ǉ����邽�߂�Hook�B

���ŁA

```
parent.AddTask
```

���邱�ƂŎ��s���Ɏq�^�X�N��ǉ��ł���B

## Subscribe
�^�X�N�̎��s���J�n����B
���s���ʂ𓾂�B


# Scheduler
## StepScheduler
Unity
## CurrentThreadScheduler
����
## ThreadPoolScheduler
�X���b�h
## ThreadScheduler
�X���b�h

