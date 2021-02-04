import React from "react"

const DisplayQuestionDot = ({ result }) => {
    return
    {
        result.fretboard.intFretboard.map((fret, i) => {
            console.log("in dispay dot")
            return fret.map((note, j) => {
                return (
                    <circle
                        key={`${i}-${j}`}
                        id={`note--${i}-${j}`}
                        cx={21 + (110 * i)} cy={25 + (34 * j)} r="15"
                        fill="#39FF14"
                        visibility={(i === result.questions.slice(-1)[0][0] && j === result.questions.slice(-1)[0][1]) ? "visible" : "hidden"}
                    />

                )
            });
        })
    }

}
export default DisplayQuestionDot;