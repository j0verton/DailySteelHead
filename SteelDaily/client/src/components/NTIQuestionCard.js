import React, { useContext, useState } from "react";
import { toast } from "react-toastify";
import { Button, Card, Col } from "reactstrap";
import ReactCardFlip from 'react-card-flip';

const NTIQuestionCard = () => {

    return (
        <Col sm="12" md={{ size: 6, offset: 3 }}>
            <Card>
                What interval of <br />
                <h2>C</h2><br />
                is at the<br />
                <h2>8th fret</h2><br />
                on the <br />
                <h2>8th string</h2>

            </Card>
        </Col >

        //give correct/incorrect via toast or a flipping card

    )
};
export default NTIQuestionCard