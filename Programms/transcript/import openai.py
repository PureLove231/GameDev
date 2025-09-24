import openai
from openai import OpenAI

client = OpenAI(api_key="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")  # Importiere das OpenAI-Modul
import os

# Setze deinen API-Schlüssel

# Pfad zur Audio-Datei
audio_file_path = "/Users/christianpeitler/Desktop/Hemi Sync /Wave 1 Gateway Expierence/CD 1/2 Intro Focus 10.aiff"

# Öffne die Audio-Datei und transkribiere sie
with open(audio_file_path, "rb") as audio_file:
    transcript = client.audio.transcribe(model="whisper-1",  # Das richtige Modell für Transkriptionen
    file=audio_file)

# Gib die Transkription aus
print(transcript.text)

try:
    with open(audio_file_path, "rb") as audio_file:
        transcript = client.audio.transcribe(model="whisper-1",
        file=audio_file)
    print(transcript.text)
except FileNotFoundError:
    print(f"Die Datei {audio_file_path} wurde nicht gefunden.")
except openai.OpenAIError as e:
    print(f"Ein Fehler ist aufgetreten: {e}")