module Scene
open PhaserInterop



type SceneExtension (config,create, update, preload) =
    inherit Scene(config)
    override this.preload () : unit = preload this.load 
    override this.create () = create this.add 
    override this.update () = update()

