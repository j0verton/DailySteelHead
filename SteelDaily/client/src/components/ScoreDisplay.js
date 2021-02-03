import react from "react"
// import 'bootstrap/dist/css/bootstrap.min.css';


const ScoreDisplay = (result) => {

    return (
        <>
            {
                result.outcomes ?
                    <>
                        <span className="glyphicon glyphicon-star" aria-hidden="true"></span>
                        <h3>{result.outcomes.filter(b => b).length}/10 Correct</h3>
                    </>
                    : <h3>Select A Key Then Begin</h3>
            }
        </>


    )
};
export default ScoreDisplay;