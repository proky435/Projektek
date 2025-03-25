#https://www.ksh.hu/stadat_files/ara/hu/ara0001.html

import pandas as pd
import matplotlib.pyplot as plt
from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg
from sklearn.linear_model import LinearRegression
import numpy as np
import tkinter as tk
from tkinter import Checkbutton, IntVar, Label, Frame
import csv

# Adatok beolvasása
data = []
def fileBe(fileName):
    try:
        with open(fileName, encoding='utf-8') as forrasfajl:
            for sor in forrasfajl.readlines()[2:]:
                adatok = sor.strip().split(';')
                adat = {
                    'Év': int(adatok[0]),
                    'Fogyasztóiár-index': float(adatok[1]),
                    'Ipari termelőiár-index': float(adatok[2]),
                    'Építőipari termelőiár-index': float(adatok[3]),
                    'Beruházásiár-index': float(adatok[4]),
                    'Szolgáltatásiár-index': float(adatok[5]),
                    'Mezőgazdasági termékek termelőiár-indexe': float(adatok[6]),
                    'Behozatal': float(adatok[7]),
                    'Kivitel': float(adatok[8])
                }
                data.append(adat)
    except FileNotFoundError:
        print(f"Hiba: A '{fileName}' fájl nem található.")
    except Exception as e:
        print(f"Hiba történt a fájl beolvasása során: {e}")

# Lineáris regresszió trendvonal
def plotRegresszio(x, y):
    x_reshaped = np.array(x).reshape(-1, 1)
    model = LinearRegression()
    model.fit(x_reshaped, y)
    y_pred = model.predict(x_reshaped)
    slope = model.coef_[0]
    intercept = model.intercept_
    equation = f"y = {slope:.2f} * x + {intercept:.2f}"  # Az egyenlet formázása
    return y_pred, slope, intercept, equation


# Adat és diagram megjelenítése checkboxok alapján
def plotData():
    ev = [adat['Év'] for adat in data]
    indices = {
        'Fogyasztóiár-index': [adat['Fogyasztóiár-index'] for adat in data],
        'Ipari termelőiár-index': [adat['Ipari termelőiár-index'] for adat in data],
        'Építőipari termelőiár-index': [adat['Építőipari termelőiár-index'] for adat in data],
        'Beruházásiár-index': [adat['Beruházásiár-index'] for adat in data],
        'Szolgáltatásiár-index': [adat['Szolgáltatásiár-index'] for adat in data],
        'Mezőgazdasági termékek termelőiár-indexe': [adat['Mezőgazdasági termékek termelőiár-indexe'] for adat in data],
        'Behozatal': [adat['Behozatal'] for adat in data],
        'Kivitel': [adat['Kivitel'] for adat in data]
    }

    results = []

    fig, ax = plt.subplots(figsize=(10, 6))
    legend_labels = []
    for label, index_values in indices.items():
        if check_vars[label].get():
            y_pred, slope, intercept, equation = plotRegresszio(ev, index_values)
            avg = np.mean(index_values)
            
            results.append({
                "Árindex": label,
                "Átlag": avg,
                "Trendvonal Meredekség": slope,
                "Trendvonal Intercept": intercept
            })

            print(f"{label} lineáris regresszió egyenlete: {equation}")  # Egyenlet kiírása

            ax.plot(ev, index_values, marker='o', label=label)
            ax.plot(ev, y_pred, linestyle="--", label=f"{label} trendvonal")
            ax.axhline(avg, color='gray', linestyle=':', label=f"{label} átlag")
            legend_labels.append(label)  # A kiválasztott jelmagyarázatok gyűjtése

    ax.set_title("Árindexek alakulása 2010-2023 között")
    ax.set_xlabel("Év")
    ax.set_ylabel("Index érték")
    ax.grid(True)

    # Megjelenítés a Tkinter ablakban
    for widget in graph_frame.winfo_children():
        widget.destroy()

    canvas = FigureCanvasTkAgg(fig, master=graph_frame)
    canvas_widget = canvas.get_tk_widget()
    canvas_widget.pack(fill=tk.BOTH, expand=True)
    canvas.draw()
    
 # Jelmagyarázat megjelenítése a checkboxok alatt
    legend_text = "Jelmagyarázat: " .join("\n").join(legend_labels)
    if(legend_text == ""):
        legend_text="jelmagyrázat:"
    legend_label.config(text=legend_text)

    # Eredmények mentése CSV-be
    with open("eredmenyek.csv", mode="w", newline="", encoding="utf-8") as file:
        writer = csv.DictWriter(file, fieldnames=["Árindex", "Átlag", "Trendvonal Meredekség", "Trendvonal Intercept"])
        writer.writeheader()
        writer.writerows(results)
    print("Az eredmények mentése megtörtént a 'eredmenyek.csv' fájlba.")

# Mindet kijelöl gomb es !kijelöl
def selectAll():
    for var in check_vars.values():
        var.set(1)  # Beállítjuk az összes checkboxot kijelöltre

def deselectAll():
    for var in check_vars.values():
        var.set(0)  # Beállítjuk az összes checkboxot kikapcsoltra

# GUI beállítás
root = tk.Tk()
root.title("Árindexek megjelenítése")

# Oldal elrendezés
frame = Frame(root)
frame.pack(side=tk.LEFT, fill=tk.BOTH, expand=False)
graph_frame = Frame(root)
graph_frame.pack(side=tk.RIGHT, fill=tk.BOTH, expand=True)

check_vars = {}
for index in ['Fogyasztóiár-index', 'Ipari termelőiár-index', 'Építőipari termelőiár-index',
              'Beruházásiár-index', 'Szolgáltatásiár-index', 'Mezőgazdasági termékek termelőiár-indexe',
              'Behozatal', 'Kivitel']:
    var = IntVar()
    check_vars[index] = var
    Checkbutton(frame, text=index, variable=var).pack(anchor='w')

# Gombok elrendezése
button_frame_1 = Frame(frame)
button_frame_1.pack()

# Mindet kijelölő és törlő gombok
select_all_button = tk.Button(button_frame_1, text="Mindet kijelöl", command=selectAll)
select_all_button.grid(row=0, column=0, padx=5, pady=5)

deselect_all_button = tk.Button(button_frame_1, text="Mindet töröl", command=deselectAll)
deselect_all_button.grid(row=0, column=1, padx=5, pady=5)

# diagram megjelenítése és kilépés
button_frame_2 = Frame(frame)
button_frame_2.pack()

button = tk.Button(button_frame_2, text="Diagram megjelenítése", command=plotData)
button.grid(row=0, column=0, padx=5, pady=5)

exit_button = tk.Button(button_frame_2, text="Kilépés", command=root.quit)
exit_button.grid(row=0, column=1, padx=5, pady=5)

# Jelmagyarázat Label a checkboxok alatt
legend_label = Label(frame, text="Jelmagyarázat: ")
legend_label.pack(pady=(10, 0))  # A jelmagyarázatot 10 pixeles távolságra helyezi a gomboktól

# Fájl beolvasása és GUI futtatása
fileBe('statadat.csv')
root.mainloop()