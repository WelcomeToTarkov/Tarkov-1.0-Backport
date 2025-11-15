import os
import json
import logging
import customtkinter as ctk

# Configure logging
logging.basicConfig(level=logging.INFO, format='%(asctime)s - %(levelname)s - %(message)s', filename='app.log', filemode='w')

class BundleGeneratorApp(ctk.CTk):
    def __init__(self):
        super().__init__()

        self.title("Bundle Generator")
        self.geometry("400x300")

        self.label = ctk.CTkLabel(self, text="Generate Bundles")
        self.label.pack(pady=20)

        self.generate_button = ctk.CTkButton(self, text="Generate Bundles", command=self.generate_bundles)
        self.generate_button.pack(pady=20)

        self.output_text = ctk.CTkTextbox(self, width=380, height=100)
        self.output_text.pack(pady=20)

    def generate_bundles(self):
        logging.info("Bundle generation started.")
        manifest = []

        # Generate voice bundles
        self.generate_voice_bundles(manifest)

        # Generate clothing retexture bundles
        self.generate_clothing_retexture_bundles(manifest)

        # Generate other bundles
        self.generate_other_bundles(manifest)

        # Get shared bundles and add dependencies
        shared_bundles = self.find_shared_bundles('.')
        self.add_shared_dependencies(manifest, shared_bundles)

        # Check for container bundles and add extra dependencies
        self.add_container_dependencies(manifest)

        # Check for scope bundles and add dependencies
        self.add_scope_dependencies(manifest)

        # Write to bundles.json
        output_dir = os.path.join('..', 'bundles.json')
        with open(output_dir, 'w') as json_file:
            json.dump({"manifest": manifest}, json_file, indent=4)
        
        logging.info("bundles.json file has been generated.")
        self.output_text.insert(ctk.END, "Bundles generated successfully!\n")

    def find_bundle_files(self, directory):
        bundle_files = []
        valid_extensions = ['.bundle', '.bigbundle', '.goblin', '.servph', '.wtt']
        for root, _, files in os.walk(directory):
            for filename in files:
                if any(filename.lower().endswith(ext) for ext in valid_extensions):
                    bundle_files.append(os.path.join(root, filename))
        return bundle_files

    def find_shared_bundles(self, directory):
        shared_bundles = []
        for root, _, files in os.walk(directory):
            for filename in files:
                if filename.lower().endswith('_shared.bundle'):
                    shared_bundles.append(os.path.join(root, filename))
        return shared_bundles

    def process_voices_subfolder(self, audio_bundle_path, voice_bundle_path, shared_bundles):
        audio_bundle_key = os.path.relpath(audio_bundle_path, '.').replace('\\', '/')
        voice_bundle_key = os.path.relpath(voice_bundle_path, '.').replace('\\', '/')

        audio_bundle_entry = {
            "key": audio_bundle_key,
            "dependencyKeys": []
        }

        voice_bundle_entry = {
            "key": voice_bundle_key,
            "dependencyKeys": [audio_bundle_key]
        }

        for shared_bundle in shared_bundles:
            shared_bundle_key = os.path.relpath(shared_bundle, '.').replace('\\', '/')
            voice_bundle_entry["dependencyKeys"].append(shared_bundle_key)

        return [audio_bundle_entry, voice_bundle_entry]

    def add_shared_dependencies(self, manifest, shared_bundles):
        for bundle in manifest:
            bundle_key = bundle["key"]
            bundle_dir = os.path.dirname(bundle_key)

            for shared_bundle in shared_bundles:
                shared_bundle_key = os.path.relpath(shared_bundle, '.').replace('\\', '/')
                shared_bundle_dir = os.path.dirname(shared_bundle_key)

                if bundle_dir == shared_bundle_dir and bundle_key != shared_bundle_key:
                    bundle["dependencyKeys"].append(shared_bundle_key)

    def generate_voice_bundles(self, manifest):
        voices_folder = os.path.join('.', 'voices')
        if os.path.exists(voices_folder):
            for root, dirs, _ in os.walk(voices_folder):
                if 'Audio' in dirs and 'Voices' in dirs:
                    audio_bundle_path = os.path.join(root, 'Audio')
                    voice_bundle_path = os.path.join(root, 'Voices')

                    audio_bundle_files = self.find_bundle_files(audio_bundle_path)
                    voice_bundle_files = self.find_bundle_files(voice_bundle_path)
                    shared_bundles = self.find_shared_bundles(voices_folder)

                    if audio_bundle_files and voice_bundle_files:
                        voices_bundles = self.process_voices_subfolder(audio_bundle_files[0], voice_bundle_files[0], shared_bundles)
                        manifest.extend(voices_bundles)

    def generate_clothing_retexture_bundles(self, manifest):
        clothing_folder = os.path.join('.', 'clothing', 'retextures')
        if os.path.exists(clothing_folder):
            clothing_bundle_files = self.find_bundle_files(clothing_folder)
            for bundle_path in clothing_bundle_files:
                relative_path = os.path.relpath(bundle_path, '.').replace('\\', '/')
                bundle = {
                    "key": relative_path,
                    "dependencyKeys": [
                        "assets/content/hands/bear/bear_hands_watch_texture.bundles",
                        "assets/content/hands/bear/bear_watch.bundle",
                        "assets/content/hands/usec/materials/watch_usec_textures",
                        "shaders",
                        "cubemaps",
                        "assets/commonassets/physics/physicsmaterials.bundle"
                    ]
                }
                manifest.append(bundle)

    def generate_other_bundles(self, manifest):
        normal_bundle_files = [bundle for bundle in self.find_bundle_files('.') if 'voices' not in bundle and 'retexture' not in bundle]
        for bundle_path in normal_bundle_files:
            relative_path = os.path.relpath(bundle_path, '.').replace('\\', '/')
            bundle = {
                "key": relative_path,
                "dependencyKeys": [
                    "shaders",
                    "cubemaps",
                    "assets/commonassets/physics/physicsmaterials.bundle"
                ]
            }
            manifest.append(bundle)

    def add_container_dependencies(self, manifest):
        extra_dependencies = [
            "assets/content/weapons/weapon_root_anim_fix.bundle",
            "assets/content/weapons/wip/kibas tuning prefabs/muzzlejets_templates/default_assets.bundle",
            "assets/systems/effects/heathaze/defaultheathaze.bundle",
            "assets/systems/effects/muzzleflash/muzzleflash.bundle",
            "assets/content/audio/weapons/generic",
            "assets/content/audio/blendoptions/assets.bundle",
            "assets/content/weapons/additional_hands/client_assets.bundle"
        ]

        for bundle in manifest:
            bundle_key = bundle["key"]
            filename = os.path.basename(bundle_key)  # Fixed variable name
            name, ext = os.path.splitext(filename)
            if name.lower().endswith('_container'):
                # Add only new dependencies
                for dep in extra_dependencies:
                    if dep not in bundle["dependencyKeys"]:
                        bundle["dependencyKeys"].append(dep)
                logging.info(f"Added extra dependencies to {bundle_key}")

    def add_scope_dependencies(self, manifest):
        scope_dependencies = [
            "shaders",
            "cubemaps",
            "assets/commonassets/physics/physicsmaterials.bundle",
            "packages/com.unity.postprocessing/postprocessing/postprocessresources.bundle",
            "assets/content/textures/holemanager/round_spec_mask.bundle",
            "assets/systems/effects/opticsight/opticsightsmasks.bundle"
        ]

        for bundle in manifest:
            bundle_key = bundle["key"]
            filename = os.path.basename(bundle_key)
            name, ext = os.path.splitext(filename)
            if name.lower().endswith('_scope'):
                # Add only new dependencies
                for dep in scope_dependencies:
                    if dep not in bundle["dependencyKeys"]:
                        bundle["dependencyKeys"].append(dep)
                logging.info(f"Added scope dependencies to {bundle_key}")

if __name__ == '__main__':
    app = BundleGeneratorApp()
    app.mainloop()